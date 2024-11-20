using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbMasterMenuRepository : IRepository<MasterMenu>
    {
        public AppDbContext AppDbContext { get; }

        public DbMasterMenuRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, MasterMenu entity)
        {
            MasterMenu data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterMenu entity)
        {
            AppDbContext.MasterMenu.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, MasterMenu entity)
        {
            MasterMenu data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterMenu Find(int id)
        {
            return AppDbContext.MasterMenu
                .SingleOrDefault(data => data.MasterMenuId == id);
        }

        public void Update(int id, MasterMenu entity)
        {
            AppDbContext.MasterMenu.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<MasterMenu> View()
        {
            return AppDbContext.MasterMenu
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<MasterMenu> ViewForClient()
        {
            return AppDbContext.MasterMenu
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
