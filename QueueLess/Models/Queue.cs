using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueLess.Models
{
    public class Queue
    {
        public int ID { get; set; }
        public string Service { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string RegistrationTime { get; set; }
        public string CurrentTime { get; set; }
        public int EstimatedMinutes { get; set; }
        public int PeopleOnQueue { get; set; }


        public Queue()
        {

        }
        public Queue(string Service, string FirstName, string LastName, string PhoneNumber, string Email, string RegistrationTime, string CurrentTime, int EstimatedMinutes, int PeopleOnQueue)
        {
            this.Service = Service;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.RegistrationTime = RegistrationTime;
            this.CurrentTime = CurrentTime;
            this.EstimatedMinutes = EstimatedMinutes;
            this.PeopleOnQueue = PeopleOnQueue;

        }  
    }
}