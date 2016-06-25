using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ReportMetadata
    {
        public string Id { get; set; }

        public string ReportId { get; set; }
        
        public DateTime Date { get; set; }

        public List<List<object>> Data { get; set; }
    }
}
