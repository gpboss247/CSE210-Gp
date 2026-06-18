// The responsibility of Address is to store a physical mailing address
// and to report whether it is located in the USA.
public class Address
{
    // Private member variables - only this class can access them directly
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    // Constructor to set up an address with all four fields
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city          = city;
        _stateProvince = stateProvince;
        _country       = country;
    }

    // Returns true if this address is in the USA, false otherwise
    public bool IsInUSA()
    {
        return _country == "USA";
    }

    // Returns a formatted multi-line string of the full address
    public string GetFullAddress()
    {
        return _streetAddress + "\n" + _city + ", " + _stateProvince + "\n" + _country;
    }
}