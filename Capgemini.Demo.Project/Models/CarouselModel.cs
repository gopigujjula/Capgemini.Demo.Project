using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capgemini.Demo.Project.Models
{
    public class CarouselModel
    {
        public List<SlideModel> Slides { get; set; }
    }

    public class SlideModel
    {
        public MvcHtmlString Title { get; set; }
        public MvcHtmlString SubTitle { get; set; }
        public MvcHtmlString Link { get; set; }
        public MvcHtmlString Image { get; set; }
    }
}