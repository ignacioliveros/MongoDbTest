using Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Domain.Repository
{
    public class ReportRepository : BaseRepository<Report>
    {
        
        public ReportRepository(MongoDbContext<Report> Context)
            : base(Context)
        {           
        }

        public Report GetReportByName(string name)
        {
            var report = context.GetContext.AsQueryable().Where(x => x.Name == name).FirstOrDefault();
            return report;
        }

    }
}
