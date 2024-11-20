using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbMasterWorkingHourRepository : IRepository<MasterWorkingHour>
    {
        public AppDbContext AppDbContext { get; }

        public DbMasterWorkingHourRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, MasterWorkingHour entity)
        {
            MasterWorkingHour data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterWorkingHour entity)
        {
            AppDbContext.MasterWorkingHour.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, MasterWorkingHour entity)
        {
            MasterWorkingHour data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterWorkingHour Find(int id)
        {
            return AppDbContext.MasterWorkingHour
                .SingleOrDefault(data => data.MasterWorkingHourId == id);
        }

        public void Update(int id, MasterWorkingHour entity)
        {
            AppDbContext.MasterWorkingHour.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<MasterWorkingHour> View()
        {
            return AppDbContext.MasterWorkingHour
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<MasterWorkingHour> ViewForClient()
        {
            return AppDbContext.MasterWorkingHour
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
