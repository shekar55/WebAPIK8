using Microsoft.EntityFrameworkCore;

namespace WebAPIK8s
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DbContextClass(serviceProvider.GetRequiredService<DbContextOptions<DbContextClass>>()))
            {
                if (context.Customers.Any()) { return; }
                context.Customers.AddRange(new CustomerDetails { CustomerId = 1, CustomerName = "Akshay", CustomerAddress = "Dombivali", CustomerNumber = 12344, CustomerPinCode = 123 });
                context.SaveChanges();
            }
        }
    }
}
