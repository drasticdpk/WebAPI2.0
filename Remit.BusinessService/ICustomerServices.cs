using Remit.Entities;

namespace Remit.BusinessService
{
    public interface ICustomerServices
    {
        int CreateCustomer(CustomerEntity entity);

        bool UpdateCustomer(int customerId, CustomerEntity entity);

        bool DeleteCustomer(int customerId);

        CustomerEntity GetCustomerById(int customerId);
    }
}