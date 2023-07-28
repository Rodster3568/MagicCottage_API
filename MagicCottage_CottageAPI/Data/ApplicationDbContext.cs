using MagicCottage_CottageAPI.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicCottage_CottageAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Cottage> Cottages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cottage>().HasData(
                new Cottage()
                {
                    Id = 1,
                    Name = "Royal Cottage",
                    Details = "Featuring accommodation with a balcony, Royal Cottage Apartments is located in Ureki in the Guria Region. It features a garden and free private parking.",
                    ImageUrl = "https://avatars.mds.yandex.net/get-altay/3923637/2a0000017643b0ca787d1c5f0e0a4f99e929/XXL",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate= DateTime.Now
                },
                new Cottage()
                {
                    Id= 2,
                    Name= "Cottage Hillside",
                    Details= "Enjoy breathtaking views and serene surroundings at Cottage Hillside. This cozy retreat nestled amidst lush green hills offers a perfect getaway for nature lovers.",
                    ImageUrl= "https://example.com/cottage-hillside.jpg",
                    Occupancy= 4,
                    Rate= 150,
                    Sqft= 600,
                    Amenity= "",
                    CreatedDate = DateTime.Now
                },
                new Cottage()
                {
                    Id= 3,
                    Name= "Lakeside Retreat Cottage",
                    Details= "Escape to the tranquility of Lakeside Retreat Cottage, located by a picturesque lake. Indulge in fishing, boating, and relaxing walks along the scenic trails.",
                    ImageUrl= "https://example.com/lakeside-retreat-cottage.jpg",
                    Occupancy= 6,
                    Rate =180,
                    Sqft =700,
                    Amenity ="",
                    CreatedDate = DateTime.Now
                },
                new Cottage()
                {
                    Id = 4,
                    Name = "Cozy Woods Cabin",
                    Details = "Experience rustic charm at its best in Cozy Woods Cabin. Nestled deep within a forested area, this cabin offers peace and seclusion away from the hustle and bustle of city life.",
                    ImageUrl = "https://example.com/cozy-woods-cabin.jpg",
                    Occupancy = 5,
                    Rate = 190,
                    Sqft = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Cottage()
                {
                    Id = 5,
                    Name = "Seaside Escape Bungalow",
                    Details = "Unwind with stunning ocean views at Seaside Escape Bungalow. This charming bungalow is just steps away from the sandy beach, offering a perfect retreat for beach lovers.",
                    ImageUrl = "https://example.com/seaside-escape-bungalow.jpg",
                    Occupancy = 2,
                    Rate = 250,
                    Sqft = 400,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                });
        }
    }
}
