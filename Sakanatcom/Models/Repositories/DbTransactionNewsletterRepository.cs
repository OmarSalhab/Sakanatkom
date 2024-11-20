using Sakanatcom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Sakanatcom.Models.Repositories
{
    public class DbTransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {
        public AppDbContext AppDbContext { get; }

        public DbTransactionNewsletterRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Active(int id, TransactionNewsletter entity)
        {
            TransactionNewsletter data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(TransactionNewsletter entity)
        {
            AppDbContext.TransactionNewsletter.Add(entity);
            AppDbContext.SaveChanges();
        }

        public void Delete(int id, TransactionNewsletter entity)
        {
            TransactionNewsletter data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public TransactionNewsletter Find(int id)
        {
            return AppDbContext.TransactionNewsletter
                .SingleOrDefault(data => data.TransactionNewsletterId == id);
        }

        public void Update(int id, TransactionNewsletter entity)
        {
            AppDbContext.TransactionNewsletter.Update(entity);
            AppDbContext.SaveChanges();
        }

        public IList<TransactionNewsletter> View()
        {
            return AppDbContext.TransactionNewsletter
                .Where(data => !data.IsDelete)
                .ToList();
        }

        public IList<TransactionNewsletter> ViewForClient()
        {
            return AppDbContext.TransactionNewsletter
                .Where(data => !data.IsDelete && data.IsActive)
                .ToList();
        }
    }
}
