namespace QueueLess.Migrations
{
    using QueueLess.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QueueLess.Models.QueueDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "QueueLess.Models.QueueDbContext";
        }

        protected override void Seed(QueueLess.Models.QueueDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Queues.AddOrUpdate(
                q => q.ID,
                new Queue {Service ="New", FirstName = "Andrew", LastName = "Robert", PhoneNumber= "2345678991", Email= "A@gmail.com", RegistrationTime="09:00 AM", CurrentTime="10:30 AM", EstimatedMinutes= 90, PeopleOnQueue =3 },
                new Queue {Service ="Existing", FirstName = "Albert", LastName = "Rogers", PhoneNumber= "3456789912", Email= "AR@gmail.com", RegistrationTime="10:00 AM", CurrentTime="10:30 AM", EstimatedMinutes= 30, PeopleOnQueue =2 },
                new Queue {Service ="New", FirstName = "Joss", LastName = "Mike", PhoneNumber= "4567899123", Email= "Jm@gmail.com", RegistrationTime="11:00 AM", CurrentTime="12:30 AM", EstimatedMinutes= 90, PeopleOnQueue =5 },
                new Queue {Service ="Existing", FirstName = "Franklin", LastName = "John", PhoneNumber= "5678991234", Email= "Fj@gmail.com", RegistrationTime="12:00 AM", CurrentTime="12:45 AM", EstimatedMinutes= 45, PeopleOnQueue =4 });
        }
    }
}
