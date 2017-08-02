using AutoMapper;
using Remit.Data;
using Remit.Data.UnitOfWork;
using Remit.Entities;
using System.Transactions;

namespace Remit.BusinessService.Imp
{
    public class CustomerServices : ICustomerServices
    {
        private readonly UnitOfWork _unitOfWork;

        public CustomerServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int CreateCustomer(CustomerEntity entity)
        {
            using (var scope = new TransactionScope())
            {
                var customer = new Customer()
                {
                    Name = entity.Name,
                    PhoneNo = entity.PhoneNo
                };
                _unitOfWork.CustomerRepository.Insert(customer);
                _unitOfWork.Save();
                scope.Complete();
                return customer.Id;
            }
        }

        public bool UpdateCustomer(int customerId, CustomerEntity entity)
        {
            var success = false;
            if (entity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var customer = _unitOfWork.CustomerRepository.GetByID(customerId);
                    if (customer != null)
                    {
                        customer.Name = entity.Name;
                        customer.PhoneNo = entity.PhoneNo;
                        _unitOfWork.CustomerRepository.Update(customer);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteCustomer(int customerId)
        {
            var success = false;
            if (customerId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var customer = _unitOfWork.CustomerRepository.GetByID(customerId);
                    if (customer != null)
                    {
                        _unitOfWork.CustomerRepository.Delete(customer);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public CustomerEntity GetCustomerById(int customerId)
        {
            var customer = _unitOfWork.CustomerRepository.GetByID(customerId);
            if (customer != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Customer, CustomerEntity>());
                return Mapper.Map<CustomerEntity>(customer);
            }
            return null;
        }
    }
}