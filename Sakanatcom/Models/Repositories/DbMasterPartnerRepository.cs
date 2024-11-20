using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbMasterPartnerRepository : IRepository<MasterPartner>
    {
        public AppDbContext AppDbContext { get; }

        public DbMasterPartnerRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, MasterPartner entity)
        {
            MasterPartner data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterPartner entity)
        {
            AppDbContext.MasterPartner.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, MasterPartner entity)
        {
            MasterPartner data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterPartner Find(int id)
        {
            return AppDbContext.MasterPartner
                .SingleOrDefault(data => data.MasterPartnerId == id);
        }

        public void Update(int id, MasterPartner entity)
        {
            AppDbContext.MasterPartner.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<MasterPartner> View()
        {
            return AppDbContext.MasterPartner
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<MasterPartner> ViewForClient()
        {
            return AppDbContext.MasterPartner
                .Where(data => !data.IsDelete && data.IsActive)
                 .ToList();
        }
    }
}
