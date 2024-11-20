using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbMasterSocialMediaRepository : IRepository<MasterSocialMedia>
    {
        public AppDbContext AppDbContext { get; }

        public DbMasterSocialMediaRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, MasterSocialMedia entity)
        {
            MasterSocialMedia data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterSocialMedia entity)
        {
            AppDbContext.MasterSocialMedia.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, MasterSocialMedia entity)
        {
            MasterSocialMedia data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterSocialMedia Find(int id)
        {
            return AppDbContext.MasterSocialMedia
                .SingleOrDefault(data => data.MasterSocialMediaId == id);
        }

        public void Update(int id, MasterSocialMedia entity)
        {
            AppDbContext.MasterSocialMedia.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<MasterSocialMedia> View()
        {
            return AppDbContext.MasterSocialMedia
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<MasterSocialMedia> ViewForClient()
        {
            return AppDbContext.MasterSocialMedia
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
