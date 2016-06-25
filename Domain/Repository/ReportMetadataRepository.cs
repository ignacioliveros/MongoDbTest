using Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class ReportMetadataRepository : BaseRepository<ReportMetadata>
    {

        public ReportMetadataRepository(MongoDbContext<ReportMetadata> Context) 
            : base(Context)
        {
        }     
            

        public void SeedRepoMeta(string reportId)
        {
            
            ReportMetadata rM = new ReportMetadata
            {
                Id=Guid.NewGuid().ToString(),                
                Date=DateTime.Today,
                ReportId= reportId

            };

            context.GetContext.InsertOne(rM);
        }
    }
}
