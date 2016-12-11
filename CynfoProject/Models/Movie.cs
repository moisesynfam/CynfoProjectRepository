using CynfoProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CynfoProject.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }




    public partial class beacon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idBeacon { get; set; }

        [StringLength(17)]
        public string beaconAddress { get; set; }

        public int beaconMajor { get; set; }

        public int? beaconMinor { get; set; }


        public virtual ICollection<ad> ads { get; set; }
    }

    public class ad
    {

        public int ID { get; set; }

        public string adTitle { get; set; }


        public string adDescription { get; set; }

        public string adMediaUrl { get; set; }


        public DateTime adPublishedDate { get; set; }


        public DateTime adFinishedDate { get; set; }

        public int adMinor { get; set; }

        public string adArea { get; set; }



    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ad> ads { get; set; }
        public DbSet<beacon> beacons { get; set; }
        public DbSet<Place> places { get; set; }
    }
}