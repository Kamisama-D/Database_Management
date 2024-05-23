using musicstoreapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace musicstoreapp.ViewModels
{
    public class AnalysisViewModel
    {
        public List<TopProduct> TopProduct { get; set; }
        public List<SalesAndProfits> SalesAndProfits { get; set; }
        public List<RegionSales> RegionSales { get; set; }
    }
}