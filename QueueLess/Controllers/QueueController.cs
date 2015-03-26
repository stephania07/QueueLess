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
            string AccountSid = ConfigurationManager.AppSettings["ACcb670e71395fcf1b0132d004b46ea478"];
            string AuthToken = ConfigurationManager.AppSettings["2c182adb1c84501d546aa72e1b42568f"];

            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var message = twilio.SendSmsMessage("+14108073125", "+12025693450", "Hello");

            //if (message.RestException != null)
            //{
            //    var error = message.RestException.Message;
            //    // return ;
            //}
            //else
            //{
                return new HttpResponseMessage(HttpStatusCode.OK);
            //}
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
