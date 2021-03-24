using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.Models.ViewModels
{
    public class HallViewModel
    {
        public List<Hall> Halls { get; set; }
        public List<Hall> HallsSingle { get; set; }
        public int? HallId { get; set; }
    }
}