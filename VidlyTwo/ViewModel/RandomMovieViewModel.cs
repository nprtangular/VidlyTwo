using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyTwo.Models;

namespace VidlyTwo.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }

    }
}