namespace Keylol.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastDailyRewardTime : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.KeylolUsers", "LastVisitTime", "LastDailyRewardTime");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.KeylolUsers", "LastDailyRewardTime", "LastVisitTime");
        }
    }
}
