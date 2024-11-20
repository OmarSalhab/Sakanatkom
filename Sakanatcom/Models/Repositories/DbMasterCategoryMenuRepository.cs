using Microsoft.AspNetCore.Identity;
using Sakanatcom.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbMasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {

        public AppDbContext AppDbContext { get; }

        public DbMasterCategoryMenuRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, MasterCategoryMenu entity)
        {
            MasterCategoryMenu data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterCategoryMenu entity)
        {
            AppDbContext.MasterCategoryMenu.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, MasterCategoryMenu entity)
        {
            MasterCategoryMenu data = Find(id);
            data.IsDelete = true;
            data.EditDate = DateTime.UtcNow;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }



        public MasterCategoryMenu Find(int id)
        {
            return AppDbContext.MasterCategoryMenu
                .SingleOrDefault(data =>
                data.MasterCategoryMenuId == id);
        }

        public void Update(int id, MasterCategoryMenu entity)
        {
            AppDbContext.MasterCategoryMenu.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<MasterCategoryMenu> View()
        {
            return AppDbContext.MasterCategoryMenu
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<MasterCategoryMenu> ViewForClient()
        {
            return AppDbContext.MasterCategoryMenu
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
