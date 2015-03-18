using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueLess.Models;

namespace QueueLess.Repository
{
    interface IQueueRepository
    {
        int GetCount();
        void Add(Queue P);
        void Delete(Queue P);
        void Clear();
    }
}
