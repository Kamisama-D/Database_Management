using musicstoreapp.Models;
using musicstoreapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace musicstoreapp.Controllers
{
    public class AnalysisController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        // GET: Analysis
        public ActionResult Index()
        {
            AnalysisViewModel viewModel = new AnalysisViewModel();
            // Top Product
            StringBuilder bul = new StringBuilder(200);
            bul.Append(" SELECT TOP 1 OD.AlbumId, A.Title, SUM(Quantity) AS 'TotalSales' ");
            bul.Append(" FROM [musicstore].[dbo].[OrderDetails] OD LEFT JOIN [musicstore].[dbo].[Albums] A ");
            bul.Append(" ON OD.AlbumId = A.AlbumId ");
            bul.Append(" GROUP BY OD.AlbumId, A.Title ");
            bul.Append(" ORDER BY TotalSales DESC ");

            string sql = bul.ToString(); // string.Format(bul.ToString(), 1);
            var vTopProduct = storeDB.Database.SqlQuery<TopProduct>(sql).ToList();
            viewModel.TopProduct = vTopProduct.ToList();
            //return View(lstAnalysis2);

            // Total Sales and Total Profits
            bul = new StringBuilder(200);
            bul.Append(" SELECT OD.AlbumId, A.Title, SUM(Quantity) AS 'TotalSales', SUM(Quantity * UnitPrice) AS 'TotalProfits' ");
            bul.Append(" FROM [musicstore].[dbo].[OrderDetails] OD LEFT JOIN [musicstore].[dbo].[Albums] A ");
            bul.Append(" ON OD.AlbumId = A.AlbumId ");
            bul.Append(" GROUP BY OD.AlbumId, A.Title ");
            bul.Append(" ORDER BY TotalSales DESC ");

            sql = bul.ToString(); // string.Format(bul.ToString(), 1);
            var vSalesAndProfits = storeDB.Database.SqlQuery<SalesAndProfits>(sql).ToList();
            viewModel.SalesAndProfits = vSalesAndProfits.ToList();

            // Region Sales
            bul = new StringBuilder(200);
            bul.Append(" SELECT [State] AS 'Region' , SUM(Quantity) AS 'RegionS' ");
            bul.Append(" FROM [musicstore].[dbo].[OrderDetails] OD JOIN [musicstore].[dbo].[Orders] O ");
            bul.Append(" ON OD.OrderId = O.OrderId ");
            bul.Append(" GROUP BY State ");

            sql = bul.ToString(); // string.Format(bul.ToString(), 1);
            var vRegionSales = storeDB.Database.SqlQuery<RegionSales>(sql).ToList();
            viewModel.RegionSales = vRegionSales.ToList();

            return View(viewModel);
        }
    }
}