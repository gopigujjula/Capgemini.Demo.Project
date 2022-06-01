using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capgemini.Demo.Project.Models
{
    public class TestimonialModel
    {
        public string TestimonialTitle { get; set; }
        public string TestimonialSectionTitle { get; set; }
        public MvcHtmlString ClientName { get; set; }
        public MvcHtmlString Profession { get; set; }
        public MvcHtmlString TestimonialText { get; set; }
        public MvcHtmlString ClientImage { get; set; }
        public MvcHtmlString TestimonialImage { get; set; }
    }
}