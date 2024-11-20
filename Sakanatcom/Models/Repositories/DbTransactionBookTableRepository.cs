using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbTransactionBookTableRepository : IRepository<TransactionBookTable>
    {
        public AppDbContext AppDbContext { get; }

        public DbTransactionBookTableRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, TransactionBookTable entity)
        {
            TransactionBookTable data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(TransactionBookTable entity)
        {
            AppDbContext.TransactionBookTable.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, TransactionBookTable entity)
        {
            TransactionBookTable data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public TransactionBookTable Find(int id)
        {
            return AppDbContext.TransactionBookTable
                .SingleOrDefault(data => data.TransactionBookTableId == id);
        }

        public void Update(int id, TransactionBookTable entity)
        {
            AppDbContext.TransactionBookTable.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<TransactionBookTable> View()
        {
            return AppDbContext.TransactionBookTable
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<TransactionBookTable> ViewForClient()
        {
            return AppDbContext.TransactionBookTable
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
