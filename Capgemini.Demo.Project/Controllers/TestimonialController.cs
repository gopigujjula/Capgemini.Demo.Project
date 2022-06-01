using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using Capgemini.Demo.Project.Models;
using Sitecore.Web.UI.WebControls;

namespace Capgemini.Demo.Project.Controllers
{
    public class TestimonialController : Controller
    {
        public ActionResult Index()
        {
            TestimonialModel model = new TestimonialModel();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            if (dataSource != null)
            {
                //TestimonialTitle
                model.TestimonialTitle = dataSource.Fields["Testimonial Title"]?.Value;

                //TestimonialSectionTitle
                model.TestimonialSectionTitle = dataSource.Fields[new Sitecore.Data.ID("{02F78F71-BED8-408D-9BA0-751008682351}")]?.Value;

                //ClientName
                model.ClientName = new MvcHtmlString(FieldRenderer.Render(dataSource, "Client Name"));

                //Profession
                model.Profession = new MvcHtmlString(FieldRenderer.Render(dataSource, "Profession"));

                //TestimonialText
                model.TestimonialText = new MvcHtmlString(FieldRenderer.Render(dataSource, "Testimonial Text"));

                //ClientImage
                model.ClientImage = new MvcHtmlString(FieldRenderer.Render(dataSource, "Client Image", "class=img-fluid"));

                //TestimonialImage
                model.TestimonialImage = new MvcHtmlString(FieldRenderer.Render(dataSource, "Testimonial Image", "class=position-absolute w-100 h-100"));
            }

            return View("~/Views/Klean/Components/Testimonial.cshtml", model);
        }
    }
}