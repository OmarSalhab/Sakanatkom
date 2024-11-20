using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbMasterContactUsInformationRepository : IRepository<MasterContactUsInformation>
    {
        public AppDbContext AppDbContext { get; }

        public DbMasterContactUsInformationRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, MasterContactUsInformation entity)
        {
            MasterContactUsInformation data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterContactUsInformation entity)
        {
            AppDbContext.MasterContactUsInformation.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, MasterContactUsInformation entity)
        {
            MasterContactUsInformation data = Find(id);
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterContactUsInformation Find(int id)
        {
            return AppDbContext.MasterContactUsInformation
                .SingleOrDefault(data => 
                data.MasterContactUsInformationId == id);
        }

        public void Update(int id, MasterContactUsInformation entity)
        {
            AppDbContext.MasterContactUsInformation.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<MasterContactUsInformation> View()
        {
            return AppDbContext.MasterContactUsInformation
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<MasterContactUsInformation> ViewForClient()
        {
            return AppDbContext.MasterContactUsInformation
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
