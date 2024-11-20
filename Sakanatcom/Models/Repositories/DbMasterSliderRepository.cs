using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbMasterSliderRepository : IRepository<MasterSlider>
    {
        public AppDbContext AppDbContext { get; }

        public DbMasterSliderRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, MasterSlider entity)
        {
            MasterSlider data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterSlider entity)
        {
            AppDbContext.MasterSlider.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, MasterSlider entity)
        {
            MasterSlider data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterSlider Find(int id)
        {
            return AppDbContext.MasterSlider
                .SingleOrDefault(data => data.MasterSliderId == id);
        }

        public void Update(int id, MasterSlider entity)
        {
            AppDbContext.MasterSlider.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<MasterSlider> View()
        {
            return AppDbContext.MasterSlider
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<MasterSlider> ViewForClient()
        {
            return AppDbContext.MasterSlider
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
