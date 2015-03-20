using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Web.Http;
using QueueLess.Repository;
using QueueLess.Models;



namespace QueueLess.Controllers
{   
    //http://www.asp.net/web-api/overview/older-versions/creating-a-web-api-that-supports-crud-operations
    
    [RoutePrefix("api/Queue")]
    public class QueueController : ApiController
    {
        private QueueRepository repo = new QueueRepository();

        //GET: /api/Queue
        [HttpGet]
        [Route("")]
        public List<Queue> GetAllQueues()
        {
             //return repo.GetAll();
             List<Models.Queue> queues = new List<Models.Queue>();
             queues = repo.All().ToList();
             return queues;
        }

        //GET: /api/Queue/id
        [HttpGet]
        [Route("{id}")]
        public System.Web.Mvc.JsonResult GetQueue(int id)
        {
            var customer = repo.GetById(id);
            var json = new System.Web.Mvc.JsonResult();
            json.Data = new { customer};
            return json;
        }

        //GET :/api/Queue?Service=Service
        [HttpGet]
        [Route("{service}")]
        public IEnumerable<Queue> GetByService(string service)
        {
            return repo.All().Where(
                p => string.Equals(p.Service, service, StringComparison.OrdinalIgnoreCase));
        }

        //POST: /api/Queue
        [HttpPost]
        [Route("{id}")]
        public HttpResponseMessage PostQueue(Queue queue)
        {
            repo.Add(queue);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        //PUT:/api/Queue
        [HttpPut]
        [Route("Queue/update{id}")]
        public HttpResponseMessage UpdateQueue(Queue queue)
        {
            repo.Edit(queue);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        //DELETE: api/Queue/Delete
        [HttpDelete]
        [Route("")]
        public HttpResponseMessage DeleteQueue(int id)
        {
            repo.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
