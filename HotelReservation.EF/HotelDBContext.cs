using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelReservation.EF
{
    public class HotelDBContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelCategory> HotelCategorys { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<HotelImages> HotelImages { get; set; }
        public DbSet<RoomImages> RoomImages { get; set; }

        public DbSet<Address> Address { get; set; }

        public HotelDBContext():base()
        {
            
        }

        public HotelDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<HotelCategory>(hc => {
                hc.HasKey(x => x.Id);
                hc.Property(x => x.Name).HasMaxLength(70);
                hc.Property(x => x.Name).IsRequired();
                hc.HasMany(x => x.Hotels)
                    .WithOne(x => x.Category)
                    .HasForeignKey(x => x.CategoryId);

            });

            modelBuilder.Entity<RoomType>(rt => {
                rt.HasKey(x => x.Id);
                rt.Property(x => x.Name).HasMaxLength(50);
                rt.Property(x => x.Name).IsRequired();
                rt.HasMany(x => x.Rooms)
                    .WithOne(x => x.Type)
                    .HasForeignKey(x => x.TypeId);
            });


            modelBuilder.Entity<Hotel>(h => {
                h.HasKey(x => x.Id);
                h.Property(x => x.Name).HasMaxLength(70);
                h.Property(x => x.Name).IsRequired();
                h.Property(x => x.IsActive).IsRequired();
                h.HasMany(x => x.Rooms)
                    .WithOne(x => x.Hotlel)
                    .HasForeignKey(x => x.HotlelId);
                h.HasMany(x => x.Images)
                    .WithOne(x=> x.Hotel)
                    .HasForeignKey(x => x.HotelId);
                h.Ignore(x => x.MainImage);
            });

            modelBuilder.Entity<Room>(r => {
                r.HasKey(x => x.Id);
                r.Property(x => x.Name).HasMaxLength(70);
                r.Property(x => x.Name).IsRequired();
                r.HasMany(x => x.Reservations)
                    .WithMany(x => x.Rooms);
                r.Property(x => x.MaxQuantityOfPeople).IsRequired();
                r.HasMany(x => x.RoomImages)
                    .WithOne(x => x.Room)
                    .HasForeignKey(x => x.RoomId);
                r.Ignore(x => x.MainImage);
            });

            modelBuilder.Entity<Reservation>(r => {
                r.HasKey(x => x.Id);
                r.Property(x => x.Start_Date).IsRequired();
                r.Property(x => x.End_Date).IsRequired();
                r.Property(x => x.Total_Price).IsRequired();
                r.Property(x => x.CountOfAdults).IsRequired();
                r.HasOne(x => x.Guest)
                    .WithOne(x => x.Reservation)
                    .HasForeignKey<Guest>(x => x.ReservationId);
            });

            modelBuilder.Entity<HotelImages>(r => {
                r.HasKey(x => x.Id);
                r.Property(x => x.Extension).IsRequired();
                r.Property(x => x.IsMain).HasDefaultValue(false);
                r.Property(x => x.Path).IsRequired();
                r.Property(x => x.Upload_time).IsRequired();
            });

            modelBuilder.Entity<RoomImages>(r => {
                r.HasKey(x => x.Id);
                r.Property(x => x.Extension).IsRequired();
                r.Property(x => x.IsMain).HasDefaultValue(false); 
                r.Property(x => x.Path).IsRequired();
                r.Property(x => x.Upload_time).IsRequired();
            });

            modelBuilder.Entity<Guest>(r =>
            {
                r.HasKey(x => x.Id);
                r.Property(x => x.First_Name).IsRequired();
                r.Property(x => x.Last_Name).IsRequired();
                r.Property(x => x.Email).IsRequired();
                r.HasOne(x => x.Addres)
                    .WithOne()
                    .HasForeignKey<Guest>(x => x.AddresId);


            });

            modelBuilder.Entity<Address>(r =>
            {
                r.HasKey(x => x.Id);
                r.Property(x => x.Country).IsRequired();
                r.Property(x => x.Street).IsRequired();
                r.Property(x => x.StreetNumber).IsRequired();
                r.Property(x => x.ZipCode).IsRequired();
                r.Property(x => x.City).IsRequired();
            });

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=hotelreservation; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
