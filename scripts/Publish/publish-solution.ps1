Param(
  $solution = "..\..\XCHorizon.sln",
  $publishSettings = "..\..\publishsettings.targets",
  $msBuildTools = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin\msbuild.exe",
  $msBuildToolsProfessional = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\msbuild.exe",
  $msBuildToolsEnterprise = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\msbuild.exe",
  $msBuildToolsCommunity = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild.exe",
  $configuration = "debug",
  $publishPath,
  [switch]$precompile
)

$buildTool = "";

if (Test-Path  $msBuildTools) {
  $buildTool = $msBuildTools;
}elseif(Test-Path(  $msBuildToolsProfessional)){
 $buildTool = $msBuildToolsProfessional;
 }elseif(Test-Path(  $msBuildToolsCommunity)){
 $buildTool = $msBuildToolsCommunity;
}elseif(Test-Path(  $msBuildToolsEnterprise)){
 $buildTool = $msBuildToolsEnterprise;
}else{
  throw 'Could not find MSBuild.'
}


$ScriptPath = Split-Path $MyInvocation.MyCommand.Path


#Get PublishPath from PublishSettings unless supplied
if((Test-Path $publishSettings) -and ([string]::IsNullOrEmpty($publishPath))) {
	$publishSettingsXml = [xml](Get-Content $publishSettings)
    $publishPath = $publishSettingsXml.Project.PropertyGroup.publishUrl
}
else {
    $publishPath = "C:\inetpub\wwwroot\XCHorizon.sc.dev.local"
}

#Clean publish location
if (Test-Path "$publishPath\App_Config\Include\Project") {
    Remove-Item "$publishPath\App_Config\Include\Project" -Force -Recurse
}
if (Test-Path "$publishPath\App_Config\Include\Feature") {
    Remove-Item "$publishPath\App_Config\Include\Feature" -Force -Recurse
}
if (Test-Path "$publishPath\App_Config\Include\Foundation") {
    Remove-Item "$publishPath\App_Config\Include\Foundation" -Force -Recurse
}

$precompileOnPublish = "/p:PrecompileBeforePublish=true /p:UseMerge=true /p:EnableUpdateable=false"
$parameters = "/p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:Configuration=$configuration /p:publishUrl=$publishPath"

if ($precompile) {
	$parameters = "$paramaters $precompileOnPublish"
}

Invoke-Expression -Command "& '$buildTool' $solution /v:minimal /m $parameters"