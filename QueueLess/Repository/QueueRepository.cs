﻿using QueueLess.Models;
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

        public QueueRepository(string connection="QueueDbContext")
        {
            _dbContext = new QueueDbContext(connection);
            _dbContext.Queues.Load();
        }
        public IEnumerable<Models.Queue> All()
        {
            var qu = from Queue in _dbContext.Queues select Queue;
            return qu.ToList<Models.Queue>();
        }

      

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



        internal List<Queue> GetNew()
        {
            var query = from Queue in _dbContext.Queues
                        where Queue.Service == "New"
                        select Queue;
            return query.ToList<Queue>();


        }

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string From = Request["From"];
        //    string To = Request["To"];
        //    string Body = Request["Body"];

        //    if (Body == "M")
        //    {
        //        var text = "30 more minutes is given you";
        //        return text;
        //    }
        //    else 
        //    {
        //        return "Sorry To see you leave";
            
        //    }
        //}
    }
}