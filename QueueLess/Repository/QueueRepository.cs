using QueueLess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace QueueLess.Repository
{
    public class QueueRepository : IQueueRepository
    {
        public QueueDbContext _dbContext;

        public QueueRepository()
        {
            _dbContext = new QueueDbContext();
            _dbContext.Queues.Load();
        }

        public int GetCount()
        {
            return _dbContext.Queues.Count<Models.Queue>();
        }

        public void Add(Models.Queue P)
        {
            _dbContext.Queues.Add(P);
            _dbContext.SaveChanges();
        }

        public void Delete(Models.Queue P)
        {
            _dbContext.Queues.Remove(P);
        }

        public void Clear()
        {
            var a = this.All();
            _dbContext.Queues.RemoveRange(a);
        }
        public IEnumerable<Models.Queue> All()
        { 
            var qu = from Queue in _dbContext.Queues select Queue;
            return qu.ToList<Models.Queue>();
        }
        
    }
}