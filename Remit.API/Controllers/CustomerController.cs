using log4net;
using Microsoft.Practices.Unity;
using Remit.BusinessService;
using Remit.Entities;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Remit.API.Controllers
{
    public class CustomerController : ApiController
    {
        [Dependency]
        public ILog Logger
        {
            get;
            set;
        }

        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        //Post API/Customer
        public int Post([FromBody]CustomerEntity customerEntity)
        {
            return _customerServices.CreateCustomer(customerEntity);
        }

        //Put API/Customer/1
        public bool Put(int id, [FromBody]CustomerEntity customer)
        {
            if (id > 0)
            {
                return _customerServices.UpdateCustomer(id, customer);
            }
            return false;
        }

        //Delete API/Customer/1
        public bool Delete(int id)
        {
            if (id > 0)
                return _customerServices.DeleteCustomer(id);
            return false;
        }

        //// GET api/product/5
        public HttpResponseMessage Get(int id)
        {
            // if any info need to log
            // Logger.Info("Customer.Get");
            var product = _customerServices.GetCustomerById(id);
            if (product != null)
                return Request.CreateResponse(HttpStatusCode.OK, product);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }
    }
}