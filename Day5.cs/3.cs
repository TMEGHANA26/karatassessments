public class Order
{
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
 
    public double GetTotalPrice()
    {
        double total = Items.Sum(item => item.Price * item.Quantity);
 
        // Applied 10% discount if total exceeds $100
        if (total > 100)
        {
            total *= 0.9; 
        } 
        return total;
    }
}
public class OrderItem
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
public class EmailService
{
    public void SendConfirmation(string emailAddress)
    {
        
        Console.WriteLine($"Confirmation email sent to {emailAddress}");
    }
}
public class OrderProcessor
{
    private readonly EmailService emailService;
 
    public OrderProcessor(EmailService service)
    {
        emailService = service;
    }
 
    public void ProcessOrder(Order order, string customerEmail)
    {
        double total = order.GetTotalPrice(); 
        Console.WriteLine($"Order total: ${total:F2}");
 
        emailService.SendConfirmation(customerEmail); 
    }
}