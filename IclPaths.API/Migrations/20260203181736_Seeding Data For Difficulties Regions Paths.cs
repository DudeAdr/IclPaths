using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IclPaths.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesRegionsPaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Easy" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Medium" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "IS-1", "Capital Region (Höfuðborgarsvæðið)", "https://commons.wikimedia.org/wiki/Special:FilePath/Capital%20Region%2C%20Iceland%20-%20panoramio%20(15).jpg" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "IS-2", "Southern Peninsula (Suðurnes)", "https://commons.wikimedia.org/wiki/Special:FilePath/Southern%20Peninsula%20Region%2C%20Iceland%20-%20panoramio.jpg" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "IS-3", "Western Region (Vesturland)", "https://commons.wikimedia.org/wiki/Special:FilePath/Western%20Region%2C%20Iceland%20-%20panoramio.jpg" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "IS-4", "Westfjords (Vestfirðir)", "https://commons.wikimedia.org/wiki/Special:FilePath/Westfjords%20Region%2C%20Iceland%20-%20panoramio%20(5).jpg" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "IS-5", "Northwestern Region (Norðurland vestra)", "https://commons.wikimedia.org/wiki/Special:FilePath/Northwestern%20Region%2C%20Iceland%20-%20panoramio.jpg" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "IS-6", "Northeastern Region (Norðurland eystra)", "https://commons.wikimedia.org/wiki/Special:FilePath/Northeastern%20Region%2C%20Iceland%20-%20panoramio%20(24).jpg" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "IS-7", "Eastern Region (Austurland)", "https://commons.wikimedia.org/wiki/Special:FilePath/Eastern%20Region%2C%20Iceland%20-%20panoramio%20(1).jpg" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "IS-8", "Southern Region (Suðurland)", "https://commons.wikimedia.org/wiki/Special:FilePath/South%2C%20Iceland%20-%20panoramio.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Paths",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "PathImageUrl", "RegionId" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Iconic multi-day trek through geothermal valleys, mountains and glaciers.", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), 55.0, "Laugavegur Trail", "https://commons.wikimedia.org/wiki/Special:FilePath/Laugavegur_trail.jpg", new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Mountain trail between two glaciers with waterfalls and volcanic landscapes.", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), 25.0, "Fimmvörðuháls Pass", "https://commons.wikimedia.org/wiki/Special:FilePath/Fimmvorduhals_hike.jpg", new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Hike to Iceland’s second-highest waterfall with river crossings and caves.", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), 7.5, "Glymur Waterfall Hike", "https://commons.wikimedia.org/wiki/Special:FilePath/Glymur_waterfall_hike.jpg", new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "Remote Arctic wilderness hike with cliffs, foxes and dramatic coastline.", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), 15.0, "Hornstrandir Coastal Trail", "https://commons.wikimedia.org/wiki/Special:FilePath/Hornstrandir_coast.jpg", new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "Popular hike near Reykjavík with panoramic views over the capital region.", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), 6.5, "Mt. Esja Trail", "https://commons.wikimedia.org/wiki/Special:FilePath/Mount_Esja_hike.jpg", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "Easy walk along Europe’s most powerful waterfall in a volcanic canyon.", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 3.0, "Dettifoss River Trail", "https://commons.wikimedia.org/wiki/Special:FilePath/Dettifoss_hike.jpg", new Guid("66666666-6666-6666-6666-666666666666") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Paths",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));
        }
    }
}
