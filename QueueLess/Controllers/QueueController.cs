using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Web.Http;
using QueueLess.Repository;
using QueueLess.Models;
using Twilio;
using System.Configuration;



namespace QueueLess.Controllers
{   
    //http://www.asp.net/web-api/overview/older-versions/creating-a-web-api-that-supports-crud-operations
    
    [RoutePrefix("api/queue")]
    public class QueueController : ApiController
    {
        private QueueRepository repo = new QueueRepository();

        //GET: /api/queue
     
        [HttpGet]
        [Route("")]
        public List<QueueLess.Models.Queue> GetAllQueues()
        {
             //return repo.GetAll();
             List<Models.Queue> queues = new List<Models.Queue>();
             queues = repo.All().ToList();
             return queues;
        }

        //GET: /api/queue/id
        [HttpGet]
        [Route("{id}")]
        public System.Web.Mvc.JsonResult GetQueue(int id)
        {
            var customer = repo.GetById(id);
            var json = new System.Web.Mvc.JsonResult();
            json.Data = new { customer};
            return json;
        }

        //GET :/api/queue/id/service
        [HttpGet]
        [Route("{id}/{Service}")]
        public IEnumerable<QueueLess.Models.Queue> GetByService(string service)
        {
            return repo.All().Where(
                p => string.Equals(p.Service, service, StringComparison.OrdinalIgnoreCase));
        }
        [HttpGet]
        [Route ("{id}/New")]
        public List<QueueLess.Models.Queue> GetByNew()
        {
             return repo.GetNew();         
        }
        //POST: /api/queue
        [HttpPost]
        [Route("")]
        public HttpResponseMessage PostQueue(QueueLess.Models.Queue queue)
        {
            
            repo.Add(queue);
            // Find your Account Sid and Auth Token at twilio.com/user/account
            string AccountSid = "AC465dea63a4443cfbf0dfaf79c2c51332";
            string AuthToken = "c93cbe8364424833d25272141bb80ea1";
            //string MessageC;
   
            //if (queue)
            //{
            //    var p = "{{ queueLength }}";
            //    var t = "{{queueLength * 20 }}";
            //    MessageC = "You are the " + p + "person in the queue." +  t + "minutes are left for you.";
            //   // MessageC = "You are the {{queueLength}}person on queue.  {{queueLength * 20}} minutes are left for you.";
            //}
            // else
            // {
            //    MessageC = "You are the {{queueLength}}person on queue.  {{queueLength * 15}} minutes are left for you.";
            // }

            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var clientP = "+1" + queue.PhoneNumber;
            var message = twilio.SendSmsMessage("+14108073191", clientP, "Yeaa we made it this far.. Congratulation! And you r my first customer on my new app...guess who??"); 
    
            
                return new HttpResponseMessage(HttpStatusCode.OK);         
        }

        //PUT:/api/queue/id
        [HttpPut]
        [Route("{id}")]
        public HttpResponseMessage UpdateQueue(QueueLess.Models.Queue queue)
        {
            repo.Edit(queue);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        //DELETE: api/queue/id
        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteQueue(int id)
        {
            repo.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
