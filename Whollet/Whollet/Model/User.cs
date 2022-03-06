using System;
using SQLitePCL;
using Xamarin.Forms;
using Xamarin.Essentials;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

namespace Whollet.Model
{   [Table("Users")]
    public class User
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password 
        {
            get
            {
                var _unlock1 = SecureStorage.GetAsync(FirstName + LastName + "key").Result;
                var _unlock2 = SecureStorage.GetAsync(_unlock1).Result;
                return _unlock2;
            }
            set
            {
                var _passKey = RandomString(20);
                SecureStorage.SetAsync(FirstName + LastName + "key", _passKey);
                SecureStorage.SetAsync(_passKey, value);
               // _password = value;
            }
        }
        public string Pincode { get; set; }
        public byte[] NationalID { get; set; } 
        public byte[] Passport { get; set; } 
        public byte[] Drivers_license { get; set; }

        [ForeignKey(typeof(Address))]
        public int AddressID { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Address address { get; set; }
       

        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            var _random = new Random();
            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
    

}
