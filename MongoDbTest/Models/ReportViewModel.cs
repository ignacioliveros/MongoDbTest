using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDbTest.Models
{
    public class ReportViewModel
    {    
       
        public Report Report { get; set; }

        public List<Report> Reports { get; set; }
    }   
}