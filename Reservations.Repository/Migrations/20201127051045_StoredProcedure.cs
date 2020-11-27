using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservations.Repository.Migrations
{
    public partial class StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[Get_Contact_By_Name]
                        @name varchar(50)
                       AS
                       BEGIN
                       SET NOCOUNT ON;
                       Select * from Contacts Where Contacts.Name = @name
                       END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
