using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace TodoEc2.Infrastructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_TODO, "Create table to save the task's information")]
    public class Version0000002 : VersionBase
    {
        public override void Up()
        {
            CreateTable("Todos")
                .WithColumn("Title").AsString(255).NotNullable()
                .WithColumn("Description").AsString(2000).Nullable()
                .WithColumn("Status").AsInt32().NotNullable()
                .WithColumn("UserId").AsInt64().NotNullable().ForeignKey("FK_Todo_User_Id", "Users", "Id");
        }
    }
}