using Sitecore.ContentSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XCHorizon.Foundation.SitecoreExtensions.Indexing
{
    public class IndexedItem
    {
        [IndexField(IndexesFieldsNames.IndexName)]
        public string IndexName { get; set; }


        [IndexField(IndexesFieldsNames.StandardValues)]
        public List<string> StandardValues { get; set; }


        [IndexField(IndexesFieldsNames.ParsedLanguages)]
        public string ParsedLanguages { get; set; }


        [IndexField(IndexesFieldsNames.ShortDescription)]
        public string ShortDescription { get; set; }


        [IndexField(IndexesFieldsNames.ShouldNotOrganizeInBucket)]
        public string ShouldNotOrganizeInBucket { get; set; }


        [IndexField(IndexesFieldsNames.SiteSM)]
        public List<string> SiteSM { get; set; }


        [IndexField(IndexesFieldsNames.Language)]
        public string Language { get; set; }


        [IndexField(IndexesFieldsNames.ShortDescriptionT)]
        public string ShortDescriptionT { get; set; }


        [IndexField(IndexesFieldsNames.ParsedCreatedBy)]
        public string ParsedCreatedBy { get; set; }


        [IndexField(IndexesFieldsNames.TitleTEn)]
        public string TitleTEn { get; set; }


        [IndexField(IndexesFieldsNames.FullPath)]
        public string FullPath { get; set; }


        [IndexField(IndexesFieldsNames.ParsedUpdateBy)]
        public string ParsedUpdateBy { get; set; }


        [IndexField(IndexesFieldsNames.SmallCreatedDate)]
        public string SmallCreatedDate { get; set; }

        [IndexField(IndexesFieldsNames.UniqueID)]
        public string UniqueID { get; set; }

        [IndexField(IndexesFieldsNames.RequireRegistration)]
        public string RequireRegistration { get; set; }

        [IndexField(IndexesFieldsNames.IsPointOfInterest)]
        public string IsPointOfInterest { get; set; }

        [IndexField(IndexesFieldsNames.HasChildren)]
        public string HasChildren { get; set; }

        [IndexField(IndexesFieldsNames.Description)]
        public string Description { get; set; }

        [IndexField(IndexesFieldsNames.Version)]
        public string Version { get; set; }

        [IndexField(IndexesFieldsNames.EnforceVersionPresence)]
        public string EnforceVersionPresence { get; set; }

        [IndexField(IndexesFieldsNames.Datasource)]
        public string Datasource { get; set; }

        [IndexField(IndexesFieldsNames.LatestVersion)]
        public string LatestVersion { get; set; }

        [IndexField(IndexesFieldsNames.DescriptionT)]
        public string DescriptionT { get; set; }

        [IndexField(IndexesFieldsNames.Creator)]
        public string Creator { get; set; }

        [IndexField(IndexesFieldsNames.IsBucketText)]
        public string IsBucketText { get; set; }

        [IndexField(IndexesFieldsNames.Group)]
        public string Group { get; set; }

        [IndexField(IndexesFieldsNames.TemplateName)]
        public string TemplateName { get; set; }

        [IndexField(IndexesFieldsNames.Parent)]
        public string Parent { get; set; }

        [IndexField(IndexesFieldsNames.Template)]
        public string Template { get; set; }

        [IndexField(IndexesFieldsNames.SmallUpdateDateT)]
        public string SmallUpdateDateT { get; set; }

        [IndexField(IndexesFieldsNames.IsTamplateB)]
        public string IsTamplateB { get; set; }

        [IndexField(IndexesFieldsNames.CreatedBY)]
        public string CreatedBY { get; set; }

        [IndexField(IndexesFieldsNames.Culture)]
        public string Culture { get; set; }

        [IndexField(IndexesFieldsNames.TitleT)]
        public string TitleT { get; set; }


        [IndexField(IndexesFieldsNames.ContentTest)]
        public List<string> ContentTest { get; set; }

        [IndexField(IndexesFieldsNames.EnableItemFallbackB)]
        public string EnableItemFallbackB { get; set; }

        [IndexField(IndexesFieldsNames.Name)]
        public string Name { get; set; }

        [IndexField(IndexesFieldsNames.Database)]
        public string Database { get; set; }

        [IndexField(IndexesFieldsNames.Version2)]
        public string Version2 { get; set; }

        [IndexField(IndexesFieldsNames.IndexTimeStamp)]
        public string IndexTimeStamp { get; set; }

        [IndexField(IndexesFieldsNames.WorkFLowState)]
        public string WorkFLowState { get; set; }

        [IndexField(IndexesFieldsNames.Path)]
        public List<string> Path { get; set; }

    }
}