// The responsibility of Order is to hold a list of products and a customer,
// calculate the total cost including shipping, and produce packing and shipping labels.
public class Order
{
    // Private member variables
    private List<Product> _products;
    private Customer _customer;

    // Shipping costs
    private double _usaShipping         = 5.0;
    private double _internationalShipping = 35.0;

    // Constructor to create an order for a specific customer
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Adds a product to this order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Calculates and returns the total cost of the order.
    // This is the sum of all product costs plus the shipping cost.
    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping based on whether the customer is in the USA
        if (_customer.IsInUSA())
        {
            total += _usaShipping;
        }
        else
        {
            total += _internationalShipping;
        }

        return total;
    }

    // Returns a packing label listing the name and product ID of each product
    public string GetPackingLabel()
    {
        string label = "--- Packing Label ---\n";

        foreach (Product product in _products)
        {
            label += "  " + product.GetName() + " (ID: " + product.GetProductId() + ")\n";
        }

        return label;
    }

    // Returns a shipping label with the customer's name and full address
    public string GetShippingLabel()
    {
        string label = "--- Shipping Label ---\n";
        label += _customer.GetName() + "\n";
        label += _customer.GetAddressText() + "\n";
        return label;
    }
}