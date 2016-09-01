using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using CodeFirstAppService.DataObjects;

namespace CodeFirstAppService.Models
{
    public class CodeFirstAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public CodeFirstAppContext() : base(connectionStringName)
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        } 

        public DbSet<TodoItem> TodoItems { get; set; }//unnecessary, used only for testing
        public DbSet<Position> Position { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<CandidatePosition> CandidatePosition { get; set; }
        public DbSet<CandidateSkill> CandidateSkill { get; set; }
        public DbSet<CandidateStatus> CandidateStatus { get; set; }
        public DbSet<Interview> Interview { get; set; }
        public DbSet<InterviewAssign> InterviewAssign { get; set; }
        public DbSet<PositionSkill> PositionSkill { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Source> Source { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<InterviewType> Type { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));

            /////////////
            base.OnModelCreating(modelBuilder);
        }
    }

}
