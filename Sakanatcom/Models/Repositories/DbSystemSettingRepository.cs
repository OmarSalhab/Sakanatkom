using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbSystemSettingRepository : IRepository<SystemSetting>
    {
        public AppDbContext AppDbContext { get; }

        public DbSystemSettingRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, SystemSetting entity)
        {
            SystemSetting data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(SystemSetting entity)
        {
            AppDbContext.SystemSetting.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, SystemSetting entity)
        {
            SystemSetting data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public SystemSetting Find(int id)
        {
            return AppDbContext.SystemSetting
                .SingleOrDefault(data => data.SystemSettingId == id);
        }

        public void Update(int id, SystemSetting entity)
        {
            AppDbContext.SystemSetting.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<SystemSetting> View()
        {
            return AppDbContext.SystemSetting
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<SystemSetting> ViewForClient()
        {
            return AppDbContext.SystemSetting
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
