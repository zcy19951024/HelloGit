namespace Bedrock_WeCath_WeiXin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyStudyDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudyDetails", "DeferTime", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudyDetails", "DeferTime", c => c.Int());
        }
    }
}
