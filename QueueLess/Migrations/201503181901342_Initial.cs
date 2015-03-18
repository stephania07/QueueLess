namespace QueueLess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Queues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Service = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        RegistrationTime = c.String(),
                        CurrentTime = c.String(),
                        EstimatedMinutes = c.Int(nullable: false),
                        PeopleOnQueue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Queues");
        }
    }
}
