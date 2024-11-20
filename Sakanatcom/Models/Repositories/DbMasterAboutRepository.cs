using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbMasterAboutRepository : IRepository<MasterAbout>
    {
        public AppDbContext AppDbContext { get; }

        public DbMasterAboutRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, MasterAbout entity)
        {
            MasterAbout data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);   
        }

        public void Add(MasterAbout entity)
        {
            AppDbContext.MasterAbout.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, MasterAbout entity)
        {
            MasterAbout data = Find(id);
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterAbout Find(int id)
        {
            return AppDbContext.MasterAbout.SingleOrDefault(data=> data.MasterAboutId == id);
        }

        public void Update(int id, MasterAbout entity)
        {
            AppDbContext.MasterAbout.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<MasterAbout> View()
        {
            return AppDbContext.MasterAbout
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<MasterAbout> ViewForClient()
        {
            return AppDbContext.MasterAbout
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
