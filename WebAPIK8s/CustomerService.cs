using Microsoft.EntityFrameworkCore;

namespace WebAPIK8s
{
    public class CustomerService : ICustomerService
    {
        public readonly DbContextClass dbContextClass;

        public CustomerService(DbContextClass dbContextClass)
        {
            this.dbContextClass = dbContextClass;
        }

        public async Task<bool> AddCustomerDetails(CustomerDetails customerDetails)
        {
            await dbContextClass.Customers.AddAsync(customerDetails);
            var result = await dbContextClass.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }

        public async Task<bool> DeteleCustomerDetails(int id)
        {
            var findCustomerData = dbContextClass.Customers.Where(_ => _.CustomerId == id).FirstOrDefault();
            if(findCustomerData != null)
            {
                dbContextClass.Customers.Remove(findCustomerData);
                var result = await dbContextClass.SaveChangesAsync();
                if(result > 0) return true;
                return false;
            }
            return false;
        }
        
        public async Task<List<CustomerDetails>> GetAllCustomerDetails()
        {
            return await dbContextClass.Customers.ToListAsync();
        }
        
        public async Task<CustomerDetails> GetCustomerById(int id)
        {
            return await dbContextClass.Customers.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateCustomerDetails(CustomerDetails customerDetails)
        {
              dbContextClass.Customers.Update(customerDetails);
            var result = await dbContextClass.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }
    }
}
