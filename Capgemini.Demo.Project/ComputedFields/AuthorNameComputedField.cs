using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capgemini.Demo.Project.ComputedFields
{
    public class AuthorNameComputedField : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Item item = indexable as SitecoreIndexableItem;
            if (item == null || item.TemplateID != new Sitecore.Data.ID("{C77CBF36-E660-4C1A-AB94-85F172CA180A}"))
            {
                return null;
            }
            MultilistField authorField = item.Fields["Author"];
            if (authorField != null && authorField.Count > 0)
            {
                return authorField.GetItems().ToList().FirstOrDefault()?.Fields["First Name"]?.Value;
            }
            return null;
        }
    }
}