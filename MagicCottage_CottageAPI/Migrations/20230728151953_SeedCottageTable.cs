using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicCottage_CottageAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCottageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cottages",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Featuring accommodation with a balcony, Royal Cottage Apartments is located in Ureki in the Guria Region. It features a garden and free private parking.", "https://avatars.mds.yandex.net/get-altay/3923637/2a0000017643b0ca787d1c5f0e0a4f99e929/XXL", "Royal Cottage", 5, 200, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoy breathtaking views and serene surroundings at Cottage Hillside. This cozy retreat nestled amidst lush green hills offers a perfect getaway for nature lovers.", "https://example.com/cottage-hillside.jpg", "Cottage Hillside", 4, 150, 600, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Escape to the tranquility of Lakeside Retreat Cottage, located by a picturesque lake. Indulge in fishing, boating, and relaxing walks along the scenic trails.", "https://example.com/lakeside-retreat-cottage.jpg", "Lakeside Retreat Cottage", 6, 180, 700, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Experience rustic charm at its best in Cozy Woods Cabin. Nestled deep within a forested area, this cabin offers peace and seclusion away from the hustle and bustle of city life.", "https://example.com/cozy-woods-cabin.jpg", "Cozy Woods Cabin", 5, 190, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unwind with stunning ocean views at Seaside Escape Bungalow. This charming bungalow is just steps away from the sandy beach, offering a perfect retreat for beach lovers.", "https://example.com/seaside-escape-bungalow.jpg", "Seaside Escape Bungalow", 2, 250, 400, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cottages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cottages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cottages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cottages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cottages",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
