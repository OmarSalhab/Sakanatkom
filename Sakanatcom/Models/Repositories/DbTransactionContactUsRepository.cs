using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbTransactionContactUsRepository : IRepository<TransactionContactUs>
    {
        public AppDbContext AppDbContext { get; }

        public DbTransactionContactUsRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, TransactionContactUs entity)
        {
            TransactionContactUs data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(TransactionContactUs entity)
        {
            AppDbContext.TransactionContactUs.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, TransactionContactUs entity)
        {
            TransactionContactUs data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public TransactionContactUs Find(int id)
        {
            return AppDbContext.TransactionContactUs
                .SingleOrDefault(data => data.TransactionContactUsId == id);
        }

        public void Update(int id, TransactionContactUs entity)
        {
            AppDbContext.TransactionContactUs.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<TransactionContactUs> View()
        {
            return AppDbContext.TransactionContactUs
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<TransactionContactUs> ViewForClient()
        {
            return AppDbContext.TransactionContactUs
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
