using Bedrock_WeCath_WeiXin.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Bedrock_WeCath_WeiXin.Context
{
    public class HomeContext : DbContext
    {
        public HomeContext()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<ReimbursementContext>());
            //this.Database.Initialize(false);
        }
      
        public DbSet<Master> Master { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<CourseContent> CourseContent { get; set; }
        public DbSet<ApprovalInfo> ApprovalInfo { get; set; }
        public DbSet<RelatedCourses> RelatedCourses { get; set; }
        public DbSet<StateType> StateType { get; set; }
        public DbSet<StudyCourseIinfo> StudyCourseIinfo { get; set; }
        public DbSet<StudyDetails> StudyDetails { get; set; }
        public DbSet<UserAD> UserAD { get; set; }

        public DbSet<Project> Project { get; set; }
        public DbSet<WordTime> WordTime { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}