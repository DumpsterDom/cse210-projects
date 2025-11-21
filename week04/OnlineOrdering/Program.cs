class Program
{
    static void Main(string[] args)
    {
        // Addresses
        Address addr1 = new Address("620 Lumber Ln", "New York", "NY", "USA");
        Address addr2 = new Address("7401 Frank Pl", "Toronto", "ON", "Canada");

        // Customers
        Customer customer1 = new Customer("Dom Trujillo", addr1);
        Customer customer2 = new Customer("Jodeci Grissom", addr2);

        // Products
        Product p1 = new Product("PC", "PC26", 10.99m, 3);
        Product p2 = new Product("Xbox", "XB01", 24.50m, 2);
        Product p3 = new Product("Play Station", "PS05", 5.00m, 5);
        Product p4 = new Product("Switch", "NS02", 15.75m, 1);

        // Order 1
        Order order1 = new Order(customer1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);
        order1.AddProduct(p3);

        // Order 2 
        Order order2 = new Order(customer2);
        order2.AddProduct(p2);
        order2.AddProduct(p4);

        // Display 
        Console.WriteLine("=== Order 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\n" + order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.CalculateTotalCost():F2}\n");

        Console.WriteLine("=== Order 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\n" + order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.CalculateTotalCost():F2}");
    }
}