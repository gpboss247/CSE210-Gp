// The responsibility of Customer is to store a customer's name and address,
// and to report whether they live in the USA.
public class Customer
{
    // Private member variables
    private string _name;
    private Address _address;

    // Constructor to set up a customer with a name and address
    public Customer(string name, Address address)
    {
        _name    = name;
        _address = address;
    }

    // Getter for the customer name
    public string GetName()
    {
        return _name;
    }

    // Returns true if the customer lives in the USA.
    // This asks the Address object to check - the Customer does not check directly.
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

   
    public string GetAddressText()
    {
        return _address.GetFullAddress();
    }
}