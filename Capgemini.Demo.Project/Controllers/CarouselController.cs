using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using Capgemini.Demo.Project.Models;
using Sitecore.Web.UI.WebControls;
using Sitecore.Links;

namespace Capgemini.Demo.Project.Controllers
{
    public class CarouselController : Controller
    {
        public ActionResult Index()
        {

            //var currentItem = Sitecore.Context.Item;
            //var url = LinkManager.GetItemUrl(currentItem);            
            //var aboutItem = Sitecore.Context.Database.GetItem("/sitecore/content/Klean/Data/About us/About Klean");
            //var carouselItembyID = Sitecore.Context.Database.GetItem(new Sitecore.Data.ID("{ABBC80FF-9DC4-4AD9-92A5-B73FD8540B61}"));

            List<SlideModel> slides = new List<SlideModel>();

            var datasource = RenderingContext.Current.Rendering.Item;
            MultilistField slidesField = datasource.Fields["Slides"];
            var slideItems = slidesField.GetItems();

            foreach (var slideItem in slideItems)
            {
                slides.Add(new SlideModel
                {
                    Title = new MvcHtmlString(FieldRenderer.Render(slideItem, "Slide Title")),
                    SubTitle = new MvcHtmlString(FieldRenderer.Render(slideItem, "Slide Sub Title")),
                    Link = new MvcHtmlString(FieldRenderer.Render(slideItem, "Slide Link", "class=btn btn-primary")),
                    Image = new MvcHtmlString(FieldRenderer.Render(slideItem, "Slide Image", "class=img-fluid"))
                });
            }


            return View("~/Views/Klean/Components/Carousel.cshtml", new CarouselModel { Slides = slides });
        }
    }
}