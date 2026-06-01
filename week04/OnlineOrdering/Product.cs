// The responsibility of Product is to store the details of a single product
// and to calculate its total cost based on price and quantity.
public class Product
{
    // Private member variables
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    // Constructor to set up a product with all required details
    public Product(string name, string productId, double price, int quantity)
    {
        _name      = name;
        _productId = productId;
        _price     = price;
        _quantity  = quantity;
    }

    // Getter for the product name
    public string GetName()
    {
        return _name;
    }

    // Getter for the product ID
    public string GetProductId()
    {
        return _productId;
    }

    // Returns the total cost for this product (price per unit times quantity)
    public double GetTotalCost()
    {
        return _price * _quantity;
    }
}