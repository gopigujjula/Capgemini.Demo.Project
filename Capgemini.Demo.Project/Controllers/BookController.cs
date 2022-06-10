using Capgemini.Demo.Project.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capgemini.Demo.Project.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult BookList()
        {
            string queryText = "lecture";

            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            var bookTemplateID = new Sitecore.Data.ID("{C77CBF36-E660-4C1A-AB94-85F172CA180A}");

            SearchResults<BookSearchResultItem> results;

            SitecoreIndexableItem contextItem = homeItem;

            using (var context = ContentSearchManager.GetIndex(contextItem).CreateSearchContext())
            {
                IQueryable<BookSearchResultItem> query = context.GetQueryable<BookSearchResultItem>();
                query = query.Where(f => f.TemplateId == bookTemplateID && f.Language == Sitecore.Context.Language.Name
                && f.Paths.Contains(homeItem.ID));
                if(!string.IsNullOrEmpty(queryText))
                {
                    query = query.Where(f => f.Title.Contains(queryText));
                }
                query = query.OrderBy(f => f.Title).Page(0, 25);
                results = query.GetResults();

            }

            using (var context = ContentSearchManager.GetIndex(contextItem).CreateSearchContext())
            {
                var facets = new FacetResults();

                facets = context.GetQueryable<BookSearchResultItem>()
                                .FacetOn(x => x.Publisher)
                                .GetFacets();

                foreach (var facetCategories in facets.Categories)
                {
                    foreach (var facet in facetCategories.Values)
                    {
                        // The name of the language, i.e. EN, UK or DK
                        var facetName = facet.Name;
                        // The total amount of items for given language
                        var facetAggregateCount = facet.AggregateCount;
                    }
                }
            }

            List<BookSearchResultItem> resultItems = results?.Hits.Select(f => f.Document).ToList();
            return View(resultItems);
        }
    }
}