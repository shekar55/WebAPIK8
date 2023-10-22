namespace WebAPIK8s
{
    public interface ICustomerService
    {
        public Task<List<CustomerDetails>> GetAllCustomerDetails();
        public Task<CustomerDetails> GetCustomerById( int id);
        public Task<bool> AddCustomerDetails(CustomerDetails customerDetails);
        public Task<bool> UpdateCustomerDetails(CustomerDetails customerDetails);
        public Task<bool> DeteleCustomerDetails(int id);
    }
}
