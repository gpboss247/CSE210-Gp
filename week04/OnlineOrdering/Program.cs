// W04 Foundation Program #2: Online Ordering
// Demonstrates the principle of Encapsulation.
// This program creates two orders with products and customers,
// then displays the packing label, shipping label, and total cost for each.



class Program
{
    static void Main(string[] args)
    {
       
        // Order 1 - USA customer
       
        Address address1 = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-1042", 29.99, 2));
        order1.AddProduct(new Product("USB-C Hub", "UC-8831", 45.00, 1));
        order1.AddProduct(new Product("Laptop Stand", "LS-3301", 35.50, 1));

      
        // Order 2 - International customer
    
        Address address2 = new Address("12 Baker Street", "London", "England", "UK");
        Customer customer2 = new Customer("Emily Clarke", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "MK-5570", 89.99, 1));
        order2.AddProduct(new Product("Monitor Light Bar", "ML-2290", 39.99, 2));

       
        // Display Order 1
       
        Console.WriteLine("===== ORDER 1 =====");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.GetTotalCost());
        Console.WriteLine();

        
        // Display Order 2
        
        Console.WriteLine("===== ORDER 2 =====");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order2.GetTotalCost());
        Console.WriteLine();
    }
}
  