using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RemoteMarket.Models
{
    public class WorkType
    {
        //[ScaffoldColumn(false)]
        public int WorkTypeId { get; set; }

        public string Name { get; set; }


    }
}