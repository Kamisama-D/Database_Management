using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace musicstoreapp.Models
{
    public class TopProduct
    {
        //Album Id
        public int AlbumId { get; set; }
        //Title
        public string Title { get; set; }
        //Top Product
        public int TotalSales { get; set; }
    }

    public class SalesAndProfits
    {
        //Album Id
        public int AlbumId { get; set; }
        //Title
        public string Title { get; set; }
        //Total Sales 
        public int TotalSales { get; set; }
        //Total Profits
        public decimal TotalProfits { get; set; }
    }

    public class RegionSales
    {
        //Region
        public string Region { get; set; }
        //Region Sales
        public int RegionS { get; set; }

    }
}