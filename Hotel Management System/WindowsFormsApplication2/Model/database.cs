using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2.Model
{
    class database : DbContext
    {
        public database() : base("conn")
        {

        }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }

        public virtual DbSet<Owner> Owners { get; set; }

        public virtual DbSet<expense> expenses { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<HotelFacility> HotelFacilities { get; set; }

        public virtual DbSet<RoomCat> RoomCats { get; set; }
        public virtual DbSet<roomRegister> RoomRegisters { get; set; }

        public virtual DbSet<Facility> Facilities { get; set; }

    }


    public class Room
    {
        public int Id { get; set; }
        public string Room_no { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string description { get; set; }

        public string price { get; set; }

    }


    public class HotelFacility
    {
        public int Id { get; set; }
        public string category { get; set; }
        public string item { get; set; }
        public string description { get; set; }
        public string price { get; set; }

    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string nic { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string nationality { get; set; }
        public string martialstatus { get; set; }
        [ForeignKey("Manager")]
        public int registered_by { get; set; }
        public virtual Manager Manager { get; set; }

    }

    public class Owner
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }


    }

    public class Manager
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

    }

    public class expense
    {
        public int Id { get; set; }
        public string item { get; set; }
        public string price { get; set; }
        public string descripton { get; set; }

    }


    public class RoomCat
    {
        [Key]
        public int Id { get; set; }
        public string CatName { get; set; }

        public virtual ICollection<Facility> Facilities { get; set; }
    }
    public class Facility
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("RoomCat")]
        public int RoomCat_Id { get; set; }

        public virtual RoomCat RoomCat { get; set; }

    }
    public class roomRegister
    {
        [Key]
        public int Id { get; set; }
        public string roomNo { get; set; }
        public string guestName { get; set; }
        public string time { get; set; }
        public string price { get; set; }
    }
}
