using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace musicstoreapp.Models
{
    //public class Album
    //{
    //    public int AlbumId { get; set; }
    //    public int GenreId { get; set; }
    //    public int ArtistId { get; set; }
    //    public string Title { get; set; }
    //    public decimal Price { get; set; }
    //    public string AlbumArtUrl { get; set; }
    //    public Genre Genre { get; set; }
    //    public Artist Artist { get; set; }
    //}

    //[Bind(Exclude = "AlbumId")]
    public class Album
    {
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }
        [DisplayName("Genre")]
        public int GenreId { get; set; }
        [DisplayName("Artist")]
        public int ArtistId { get; set; }
        [Required(ErrorMessage = "An Album Title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
        ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Inventory Amount is required")]
        [Range(0, 9999999,
        ErrorMessage = "Inventory Amount must be >= 0")]
        public int InventoryAmount { get; set; }

        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}