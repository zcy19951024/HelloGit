namespace Bedrock_WeCath_WeiXin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudyDetails", "StartStudyTime", c => c.DateTime());
            AddColumn("dbo.StudyDetails", "FinishStudyTime", c => c.DateTime());
            AddColumn("dbo.StudyDetails", "Studystate", c => c.Int());
            AddColumn("dbo.StudyDetails", "StopEndTime", c => c.DateTime());
            AddColumn("dbo.StudyDetails", "DeferTime", c => c.Int());
            AddColumn("dbo.StudyDetails", "ExpectFinishDate", c => c.DateTime());
            DropColumn("dbo.StudyDetails", "StartDate");
            DropColumn("dbo.StudyDetails", "EndDate");
            DropColumn("dbo.StudyDetails", "StudyDate");
            DropColumn("dbo.StudyDetails", "StopFinishTime");
            DropColumn("dbo.StudyDetails", "DeferStartTime");
            DropColumn("dbo.StudyDetails", "DeferFinishTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudyDetails", "DeferFinishTime", c => c.DateTime());
            AddColumn("dbo.StudyDetails", "DeferStartTime", c => c.DateTime());
            AddColumn("dbo.StudyDetails", "StopFinishTime", c => c.DateTime());
            AddColumn("dbo.StudyDetails", "StudyDate", c => c.Int());
            AddColumn("dbo.StudyDetails", "EndDate", c => c.DateTime());
            AddColumn("dbo.StudyDetails", "StartDate", c => c.DateTime());
            DropColumn("dbo.StudyDetails", "ExpectFinishDate");
            DropColumn("dbo.StudyDetails", "DeferTime");
            DropColumn("dbo.StudyDetails", "StopEndTime");
            DropColumn("dbo.StudyDetails", "Studystate");
            DropColumn("dbo.StudyDetails", "FinishStudyTime");
            DropColumn("dbo.StudyDetails", "StartStudyTime");
        }
    }
}
