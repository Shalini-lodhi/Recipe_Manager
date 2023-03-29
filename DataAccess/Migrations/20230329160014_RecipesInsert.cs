using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RecipesInsert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT Recipes ON;
INSERT INTO Recipes
	(   Id, Title,		[Description],																																																DateCreated,				DateUpdated)
(SELECT	1, 'Burger',	'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',																				'2021-09-04 12:03:00.000', '2021-09-05 18:30:00.000' WHERE NOT EXISTS (SELECT 1 FROM Recipes WHERE Id = 1)) UNION ALL
(SELECT	2, 'Pizza',		'Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.',												'2021-09-02 14:58:00.000', '2021-09-03 08:12:00.000' WHERE NOT EXISTS (SELECT 1 FROM Recipes WHERE Id = 2)) UNION ALL
(SELECT	3, 'Lasagne',	'Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.',		'2021-08-31 11:39:00.000', '2021-09-01 09:40:00.000' WHERE NOT EXISTS (SELECT 1 FROM Recipes WHERE Id = 3));
SET IDENTITY_INSERT Recipes OFF;
");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
