namespace Bedrock_WeCath_WeiXin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyStudyCourseIinfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudyCourseIinfo", "CourseFinishTime", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudyCourseIinfo", "CourseFinishTime", c => c.Int());
        }
    }
}
