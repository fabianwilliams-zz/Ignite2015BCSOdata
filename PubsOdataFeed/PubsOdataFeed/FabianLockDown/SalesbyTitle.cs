using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PubsOdataFeed.FabianLockDown
{
    public class SalesbyTitle
    {
        public string Title { get; set; }
        public string BookType { get; set; }
        public decimal? BookPrice { get; set; }
        public decimal? ytdSales { get; set; }
        public DateTime OrderDate { get; set; }
        public string title_id { get; set; }

    }
}