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
        private List<Queue> queues = new List<Queue>();

        public QueueRepository(string connection="QueueTest")
        {
            _dbContext = new QueueDbContext(connection);
            _dbContext.Queues.Load();
        }
        public IEnumerable<Models.Queue> All()
        {
            var qu = from Queue in _dbContext.Queues select Queue;
            return qu.ToList<Models.Queue>();
        }

        //public IEnumerable<Queue> GetAll()
        //{
        //    return queues;
        //}

        public Queue GetById(int id)
        {
            return _dbContext.Queues.Where(q => q.ID == id).First<Queue>();
        
        }

        public void Edit(Queue queue)
        {
            var qu = _dbContext.Queues.Where(q=> q.ID == queue.ID);
            foreach (Queue dbqueue in qu)
            {
                dbqueue.EstimatedMinutes = queue.EstimatedMinutes;
            }
            _dbContext.SaveChanges();
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

        public void Delete(int id)
        {
            var qu = _dbContext.Queues.Where(x=> x.ID == id);
            _dbContext.Queues.RemoveRange(qu);
            _dbContext.SaveChanges();
        }

        public void Clear()
        {
            var a = this.All();
            _dbContext.Queues.RemoveRange(a);
        }
       
        
    }
}