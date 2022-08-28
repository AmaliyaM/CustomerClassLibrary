using CustomerInformation;
using CustomerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerLibrary.Repositories;
using CustomerLibrary.Interfaces;

namespace CustomerLibrary.WebForms
{
    public partial class CustomerList : System.Web.UI.Page
    {
        private IRepository<CustomerClass> _customerRepository;
        public List<CustomerClass> Customers { get; set; }

        public CustomerList()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerList(IRepository<CustomerClass> customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public void LoadCustomersFromDatabase()
        {
            Customers = _customerRepository.GetAll();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
                LoadCustomersFromDatabase();
           
        }
        public void OnClickUpload(object sender, EventArgs e)
        {
            LoadCustomersFromDatabase();
        }
        public void OnClickAddCustomer(object sender, EventArgs e)
        {
            Response.Redirect("CustomerEdit.aspx");
        }
        



        /* public void OnClickDelete(object sender, EventArgs e)
         {
             Button btn = (Button)sender;
             labelElement.Text = btn.CommandArgument.ToString();
             var customer = new CustomerClass()
             {
                 Email = btn.CommandArgument.ToString(),
             };
             _customerRepository.Delete(customer);
         }*/
    }
}