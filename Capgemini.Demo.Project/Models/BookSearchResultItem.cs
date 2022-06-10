using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capgemini.Demo.Project.Models
{
    public class BookSearchResultItem: SearchResultItem
    {
        [IndexField("title")]
        public virtual string Title { get; set; }

        [IndexField("summary")]
        public virtual string Summary { get; set; }
        
        [IndexField("publisher")]
        public virtual string Publisher { get; set; }
        
        [IndexField("published_date")]
        public virtual DateTime PublishedDate { get; set; }        
    }
}