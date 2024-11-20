using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbMasterServiceRepository : IRepository<MasterService>
    {
        public AppDbContext AppDbContext { get; }

        public DbMasterServiceRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, MasterService entity)
        {
            MasterService data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterService entity)
        {
            AppDbContext.MasterService.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, MasterService entity)
        {
            MasterService data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterService Find(int id)
        {
            return AppDbContext.MasterService
                .SingleOrDefault(data => data.MasterServiceId == id);
        }

        public void Update(int id, MasterService entity)
        {
            AppDbContext.MasterService.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<MasterService> View()
        {
            return AppDbContext.MasterService
                .Where(data => !data.IsDelete)
                .ToList();  
        }

        public IList<MasterService> ViewForClient()
        {
            return AppDbContext.MasterService
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
