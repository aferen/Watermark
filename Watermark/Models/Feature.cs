using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Watermark.Models
{
    public class Feature
    {
        public string Title { get; set; }
        public int FontSize { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}