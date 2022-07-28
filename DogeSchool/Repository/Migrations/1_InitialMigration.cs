using FluentMigrator;

namespace DogeSchool.Repository.Migrations
{
    [Migration(1)]
    public class InitialMigration : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            Create.Schema("demongraphics");

            Create.Table("student").InSchema("demongraphics")
            .WithColumn("id").AsGuid().PrimaryKey().Unique().NotNullable()
            .WithColumn("firstname").AsString().NotNullable()
            .WithColumn("lastname").AsString().NotNullable()
            .WithColumn("birthday").AsDateTime().NotNullable();

            Create.Table("teacher").InSchema("demongraphics")
            .WithColumn("id").AsGuid().PrimaryKey().Unique().NotNullable()
            .WithColumn("firstname").AsString().NotNullable()
            .WithColumn("lastname").AsString().NotNullable();

        }

        private object WithColumn(string v)
        {
            throw new NotImplementedException();
        }

        private object withColumn(string v)
        {
            throw new NotImplementedException();
        }
    }
}
