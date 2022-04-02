namespace Whollet.Model
{
    public interface IUser
    {
        Address address { get; set; }
        int AddressID { get; set; }
        byte[] Drivers_license { get; set; }
        byte[] Drivers_licenseBackScan { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        int ID { get; set; }
        string LastName { get; set; }
        byte[] NationalID { get; set; }
        byte[] NationalIDBackScan { get; set; }
        byte[] Passport { get; set; }
        byte[] PassportBackScan { get; set; }
        string Password { get; set; }
        string Pincode { get; set; }

        string RandomString(int size, bool lowerCase = false);
    }
}