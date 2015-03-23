using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace QueueLess.Models
{
    public class Queue
    {
        public int ID { get; set; }

        [Required]
        public string Service { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Must be 10 digits")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name="Email")]
        [EmailAddress]
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