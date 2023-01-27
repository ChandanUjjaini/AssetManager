using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssetManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AssetManager.Data
{
    public class AssetManagerContext : IdentityDbContext
    {
        public AssetManagerContext (DbContextOptions<AssetManagerContext> options)
            : base(options)
        {
        }

        public DbSet<AssetManager.Models.AssetType> AssetType { get; set; } = default!;

        public DbSet<AssetManager.Models.Brand> Brand { get; set; } = default!;

        public DbSet<AssetManager.Models.Country> Country { get; set; } = default!;

        public DbSet<AssetManager.Models.Asset> Asset { get; set; } = default!;
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Models.AssetType>().HasData(new Models.AssetType { Id = 1, Name = "Desktop" });
            modelBuilder.Entity<Models.AssetType>().HasData(new Models.AssetType { Id = 2, Name = "Laptop" });
            modelBuilder.Entity<Models.AssetType>().HasData(new Models.AssetType { Id = 3, Name = "Phone" });
            modelBuilder.Entity<Models.AssetType>().HasData(new Models.AssetType { Id = 4, Name = "Printer" });

            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 1, Name = "Samsung" });
            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 2, Name = "Apple" });
            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 3, Name = "HP" });
            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 4, Name = "Dell" });
            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 5, Name = "Epson" });
            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 6, Name = "Xerox" });
            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 7, Name = "Lenovo" });

            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Algeria ", Code = "DZD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "Argentina ", Code = "ARS" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Australia ", Code = "AUD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 4, Name = "Bahrain ", Code = "BHD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 5, Name = "Bangladesh ", Code = "BDT" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 6, Name = "Belarus ", Code = "BYN" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 7, Name = "Bolivia ", Code = "BOB" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 8, Name = "Botswana ", Code = "BWP" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 9, Name = "Brazil ", Code = "BRL" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 10, Name = "Britain ", Code = "GBP" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 11, Name = "Brunei ", Code = "BND" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 12, Name = "Bulgaria ", Code = "BGN" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 13, Name = "Canada ", Code = "CAD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 14, Name = "Chile ", Code = "CLP" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 15, Name = "China ", Code = "CNY" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 16, Name = "Colombia ", Code = "COP" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 17, Name = "Costa Rica ", Code = "CRC" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 18, Name = "Croatia ", Code = "HRK" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 19, Name = "Czech Republic ", Code = "CZK" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 20, Name = "Danmark ", Code = "DKK" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 21, Name = "Dominican Republic ", Code = "DOP" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 22, Name = "Egypt ", Code = "EGP" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 23, Name = "El Salvador ", Code = "SVC" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 24, Name = "Europe", Code = "EUR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 25, Name = "Fiji ", Code = "FJD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 26, Name = "Georgia ", Code = "GEL" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 27, Name = "Ghana ", Code = "GHS" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 28, Name = "Hong Kong ", Code = "HKD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 29, Name = "Hungary ", Code = "HUF" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 30, Name = "India ", Code = "INR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 31, Name = "Indonesia ", Code = "IDR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 32, Name = "Iraq ", Code = "IQD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 33, Name = "Israel ", Code = "ILS" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 34, Name = "Japan ", Code = "JPY" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 35, Name = "Jordan ", Code = "JOD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 36, Name = "Kazakhstan ", Code = "KZT" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 37, Name = "Kenya ", Code = "KES" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 38, Name = "Kuwait ", Code = "KWD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 39, Name = "Lebanese ", Code = "LBP" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 40, Name = "Lithuania ", Code = "LTL" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 41, Name = "Macanese ", Code = "MOP" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 42, Name = "Malaysia ", Code = "MYR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 43, Name = "Mauritius ", Code = "MUR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 44, Name = "Mexico ", Code = "MXN" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 45, Name = "Morocco ", Code = "MAD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 46, Name = "Myanmar ", Code = "MMK" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 47, Name = "Namibia ", Code = "NAD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 48, Name = "Nepal ", Code = "NPR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 49, Name = "New Zealand ", Code = "NZD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 50, Name = "Nicaraguan ", Code = "NIO" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 51, Name = "Nigeria ", Code = "NGN" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 52, Name = "Norway ", Code = "NOK" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 53, Name = "Oman ", Code = "OMR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 54, Name = "Pakistan ", Code = "PKR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 55, Name = "Paraguay ", Code = "PYG" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 56, Name = "Peru ", Code = "PEN" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 57, Name = "Philippine ", Code = "PHP" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 58, Name = "Poland ", Code = "PLN" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 59, Name = "Qatar ", Code = "QAR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 60, Name = "Romania ", Code = "RON" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 61, Name = "Russia ", Code = "RUB" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 62, Name = "Saudi Arabia ", Code = "SAR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 63, Name = "Serbia ", Code = "RSD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 64, Name = "Singapore ", Code = "SGD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 65, Name = "South African ", Code = "ZAR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 66, Name = "South Korea ", Code = "KRW" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 67, Name = "Sri Lanka ", Code = "LKR" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 68, Name = "Sweden ", Code = "SEK" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 69, Name = "Switzerland ", Code = "CHF" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 70, Name = "Taiwan ", Code = "TWD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 71, Name = "Tanzania ", Code = "TZS" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 72, Name = "Thailand ", Code = "THB" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 73, Name = "Tunisia ", Code = "TND" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 74, Name = "Turky ", Code = "TRY" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 75, Name = "Uganda ", Code = "UGX" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 76, Name = "Ukrain ", Code = "UAH" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 77, Name = "United Arab Emirates ", Code = "AED" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 78, Name = "Uruguayan ", Code = "UYU" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 79, Name = "USA", Code = "USD" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 80, Name = "Uzbekistan ", Code = "UZS" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 81, Name = "Venezuela ", Code = "VES" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 82, Name = "Vietnam ", Code = "VND" });
            base.OnModelCreating(modelBuilder);

        }
    }
}
