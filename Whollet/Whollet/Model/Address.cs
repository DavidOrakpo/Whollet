using System;
using SQLitePCL;
using Xamarin.Forms;
using Xamarin.Essentials;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using SQLiteNetExtensions.Attributes;

namespace Whollet.Model
{
    public class Address
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string MyProperty { get; set; }
        public int HouseNumber { get; set; }
        public string City { get; set; }
        public string AreaCode { get; set; }
        public string Citizenship { get; set; }

        [ForeignKey(typeof(User))]
        public int UserID { get; set; }
        [OneToOne]
        public User Owner { get; set; }
    }
}
