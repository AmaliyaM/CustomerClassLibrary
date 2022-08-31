using CustomerInformation;
using CustomerLibrary.Entities;
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
    public partial class CustomerEdit : System.Web.UI.Page
    {
        private IRepository<CustomerClass> _customerRepository;

        public CustomerEdit()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerEdit(IRepository<CustomerClass> customerRepository)
        {
            _customerRepository =  customerRepository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var customerIdReq = Request.QueryString["id"]; //chsnge on id after creating
                if (customerIdReq != null)
                {
                    var customer = _customerRepository.Read(customerIdReq);

                    firstName.Text = customer.FirstName;
                    lastName.Text = customer.LastName;
                    email.Text = customer.Email;
                    phoneNumber.Text = customer.PhoneNumber;
                    totalPurchasesAmount.Text = customer.TotalPurchasesAmount.ToString();
                }
            }
            
        }

        public void OnClickSave(object sender, EventArgs e)
        {
            var customer = new CustomerClass()
            {   ID = Convert.ToInt32(Request.QueryString["id"]),
                FirstName = firstName?.Text,
                LastName = lastName?.Text,
                PhoneNumber = phoneNumber?.Text,
                Email = email?.Text,
                TotalPurchasesAmount = Convert.ToDecimal(totalPurchasesAmount?.Text)
            };
            if(Request.QueryString["id"] == null) 
                _customerRepository.Create(customer);
            else _customerRepository.Update(customer);

            Response.Redirect("CustomerList.aspx");

        }

        protected void firstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}