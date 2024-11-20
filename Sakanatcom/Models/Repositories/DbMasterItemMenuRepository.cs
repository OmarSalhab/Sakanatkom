using Microsoft.EntityFrameworkCore;
using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbMasterItemMenuRepository : IRepository<MasterItemMenu>
    {
        public AppDbContext AppDbContext { get; }

        public DbMasterItemMenuRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, MasterItemMenu entity)
        {
            MasterItemMenu data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterItemMenu entity)
        {
            AppDbContext.MasterItemMenu.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, MasterItemMenu entity)
        {
            MasterItemMenu data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterItemMenu Find(int id)
        {
            return AppDbContext.MasterItemMenu
                .Include(data => data.MasterCategoryMenu)
                .SingleOrDefault(data => data.MasterItemMenuId == id);
        }

        public void Update(int id, MasterItemMenu entity)
        {
            AppDbContext.MasterItemMenu.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<MasterItemMenu> View()
        {
            return AppDbContext.MasterItemMenu
               .Include(data => data.MasterCategoryMenu)
               .Where(data => !data.IsDelete)
               .ToList();
        }

        public IList<MasterItemMenu> ViewForClient()
        {
            return AppDbContext.MasterItemMenu
               .Include(data => data.MasterCategoryMenu)
               .Where(data => !data.IsDelete && data.IsActive)
               .ToList();
        }
    }
}
