using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskSOLEAD.Migrations
{
    public partial class spSearchCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spSearchCompany
                            @NameCompany varchar(100)
                            AS
                            BEGIN
                             Select * from [dbo].[Companies] where [Name] = @NameCompany
                            End
                            GO";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spSearchCompany";
            migrationBuilder.Sql(procedure);
        }
    }
}
