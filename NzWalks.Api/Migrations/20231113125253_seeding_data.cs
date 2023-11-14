using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NzWalks.Api.Migrations
{
    /// <inheritdoc />
    public partial class seeding_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("20625c99-f559-4ed4-bbe7-8dfafc7ab601"), "Hard" },
                    { new Guid("9a8abb6a-f43a-4ad2-a4ed-8b8f70a5d044"), "Easy" },
                    { new Guid("b8089471-c863-4eb0-a411-657fd7df70ac"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("10f1ee64-ecda-4de3-8741-215469e044c1"), "NTL", "Northland", null },
                    { new Guid("2b43b626-e631-4958-abcb-b4756f94dacf"), "AKL", "Auckland", "https://images.pexels.com/photos/18915027/pexels-photo-18915027/free-photo-of-new-zealand-urban-landscape.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("4868d396-75ca-4eda-916d-3e2741d07f86"), "STL", "Southland", null },
                    { new Guid("87d5f0fc-a8a4-4013-a76d-3f5d46e51a85"), "BOP", "Bay Of Plenty", null },
                    { new Guid("c42de26e-d673-440e-812b-d5fab236a1af"), "NSN", "Nelson", "https://images.pexels.com/photos/18915027/pexels-photo-18915027/free-photo-of-new-zealand-urban-landscape.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("e4107db2-e8b7-42cc-a520-e442a32c7c0b"), "WGN", "Wellington", "https://images.pexels.com/photos/18915027/pexels-photo-18915027/free-photo-of-new-zealand-urban-landscape.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("20625c99-f559-4ed4-bbe7-8dfafc7ab601"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9a8abb6a-f43a-4ad2-a4ed-8b8f70a5d044"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b8089471-c863-4eb0-a411-657fd7df70ac"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("10f1ee64-ecda-4de3-8741-215469e044c1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2b43b626-e631-4958-abcb-b4756f94dacf"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4868d396-75ca-4eda-916d-3e2741d07f86"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("87d5f0fc-a8a4-4013-a76d-3f5d46e51a85"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c42de26e-d673-440e-812b-d5fab236a1af"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e4107db2-e8b7-42cc-a520-e442a32c7c0b"));
        }
    }
}
