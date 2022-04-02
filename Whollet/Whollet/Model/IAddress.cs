namespace Whollet.Model
{
    public interface IAddress
    {
        string AreaCode { get; set; }
        string Citizenship { get; set; }
        string City { get; set; }
        int HouseNumber { get; set; }
        int Id { get; set; }
        string MyProperty { get; set; }
        User Owner { get; set; }
        int UserID { get; set; }
    }
}