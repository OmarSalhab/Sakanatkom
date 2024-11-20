using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbMasterOfferRepository : IRepository<MasterOffer>
    {
        public AppDbContext AppDbContext { get; }

        public DbMasterOfferRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, MasterOffer entity)
        {
            MasterOffer data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterOffer entity)
        {
            AppDbContext.MasterOffer.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, MasterOffer entity)
        {
            MasterOffer data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterOffer Find(int id)
        {
            return AppDbContext.MasterOffer
                .SingleOrDefault(data => data.MasterOfferId == id);
        }

        public void Update(int id, MasterOffer entity)
        {
            AppDbContext.MasterOffer.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<MasterOffer> View()
        {
            return AppDbContext.MasterOffer
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<MasterOffer> ViewForClient()
        {
            return AppDbContext.MasterOffer
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
