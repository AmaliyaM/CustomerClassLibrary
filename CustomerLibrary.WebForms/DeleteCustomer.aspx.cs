using CustomerInformation;
using CustomerLibrary.Interfaces;
using CustomerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerLibrary.WebForms
{
    public partial class DeleteCustomer : System.Web.UI.Page
    {
        private IRepository<CustomerClass> _customerRepository;
        public DeleteCustomer()
        {
            _customerRepository = new CustomerRepository();
        }

        public DeleteCustomer(IRepository<CustomerClass> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var customer = new CustomerClass()
            {
                ID = Convert.ToInt32(Request.QueryString["id"]),
            };
            _customerRepository.Delete(customer);
            Response.Redirect("CustomerList.aspx");

        }



    }
}