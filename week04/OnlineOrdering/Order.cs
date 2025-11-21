using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal productsTotal = 0;
        foreach (var product in _products)
        {
            productsTotal += product.GetTotalCost();
        }

        decimal shippingCost = _customer.LivesInUSA() ? 5.00m : 35.00m;
        return productsTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += product.GetPackingInfo() + "\n";
        }
        return label.Trim();
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }
}