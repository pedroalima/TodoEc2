using FluentMigrator;

namespace TodoEc2.Infrastructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_SCHEDULES, "Create table to save the schedule's information")]
    public class Version0000003 : VersionBase
    {
        public override void Up()
        {
            CreateTable("Schedules")
                .WithColumn("Date").AsInt32().NotNullable()
                .WithColumn("TodoId").AsInt64().NotNullable().ForeignKey("FK_Schedule_Todo_Id", "Todos", "Id")
                .OnDelete(System.Data.Rule.Cascade);
        }
    }
}