namespace Bedrock_WeCath_WeiXin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApprovalInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Jobnumber = c.String(maxLength: 50),
                        EmpTime = c.DateTime(),
                        HrFilo = c.String(),
                        HRApprover = c.String(maxLength: 50),
                        HRApproverTime = c.DateTime(),
                        Status = c.String(),
                        coment = c.String(maxLength: 500),
                        AccountTime = c.DateTime(),
                        AccountFilo = c.String(),
                        AccountApprover = c.String(maxLength: 50),
                        AccountApproverTime = c.DateTime(),
                        AccountStatus = c.String(),
                        AccountComent = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProcessGuid = c.String(nullable: false, maxLength: 100),
                        ActivityGuid = c.String(nullable: false, maxLength: 100),
                        OperatorAd = c.String(nullable: false, maxLength: 10),
                        Operator = c.String(nullable: false, maxLength: 20),
                        Action = c.String(nullable: false, maxLength: 10),
                        Content = c.String(nullable: false, maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseContent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(maxLength: 50),
                        Content = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Jobnumber = c.String(maxLength: 50),
                        CName = c.String(maxLength: 50),
                        EName = c.String(maxLength: 50),
                        Sex = c.String(maxLength: 50),
                        IDcare = c.String(),
                        Birthday = c.DateTime(),
                        CareAddress = c.String(maxLength: 500),
                        NowAddress = c.String(maxLength: 500),
                        Phone = c.String(maxLength: 50),
                        MaritalStatus = c.String(),
                        Education = c.String(),
                        PositionEmp = c.String(maxLength: 50),
                        Department = c.String(maxLength: 50),
                        EntryStartTime = c.DateTime(),
                        ContractStartTime = c.DateTime(),
                        ContractEndTime = c.DateTime(),
                        ProbationEndTime = c.DateTime(),
                        Probationsalary = c.String(),
                        Contractsalary = c.String(),
                        PM = c.String(maxLength: 50),
                        hrcoment = c.String(),
                        WorkState = c.String(),
                        WeChatCode = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Master",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProcessGuid = c.String(nullable: false, maxLength: 100),
                        ActivityGuid = c.String(nullable: false, maxLength: 100),
                        Folio = c.String(nullable: false, maxLength: 50),
                        Applicant = c.String(nullable: false, maxLength: 50),
                        ApplicationDate = c.DateTime(nullable: false),
                        ApplicantAd = c.String(nullable: false, maxLength: 50),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.Int(nullable: false),
                        ProcessStatus = c.String(nullable: false, maxLength: 20),
                        NextApprover = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        projectName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RelatedCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(maxLength: 50),
                        CourseInfo = c.String(maxLength: 500),
                        CourseVideo = c.String(maxLength: 500),
                        VideoInfo = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StateType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudyCourseIinfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(maxLength: 50),
                        CourseDesc = c.String(maxLength: 500),
                        CourseFinishTime = c.Double(nullable: false),
                        CourseCode = c.String(maxLength: 50),
                        CoursePrincipal = c.String(maxLength: 50),
                        CoursePM = c.String(maxLength: 50),
                        Courseimages = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudyDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Emp_Id = c.Int(),
                        CourseCode = c.String(maxLength: 50),
                        Jobnumber = c.String(maxLength: 50),
                        StartStudyTime = c.DateTime(),
                        FinishStudyTime = c.DateTime(),
                        Studystate = c.Int(),
                        isStop = c.Boolean(),
                        StopStartTime = c.DateTime(),
                        StopEndTime = c.DateTime(),
                        StopReason = c.String(maxLength: 500),
                        isDefer = c.Boolean(),
                        DeferTime = c.Int(),
                        ExpectFinishDate = c.DateTime(),
                        DeferReason = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAD",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AD = c.String(maxLength: 50),
                        ADPwd = c.String(maxLength: 50),
                        Email = c.String(maxLength: 200),
                        Password = c.String(maxLength: 50),
                        Jobnumber = c.String(maxLength: 50),
                        Desc = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WordTime",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Jobnumber = c.String(maxLength: 50),
                        WorkDate = c.String(maxLength: 50),
                        ProjectName = c.String(maxLength: 50),
                        Date = c.DateTime(),
                        Duration = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WordTime");
            DropTable("dbo.UserAD");
            DropTable("dbo.StudyDetails");
            DropTable("dbo.StudyCourseIinfo");
            DropTable("dbo.StateType");
            DropTable("dbo.RelatedCourses");
            DropTable("dbo.Project");
            DropTable("dbo.Master");
            DropTable("dbo.EmployeeInfo");
            DropTable("dbo.CourseContent");
            DropTable("dbo.Comment");
            DropTable("dbo.ApprovalInfo");
        }
    }
}
