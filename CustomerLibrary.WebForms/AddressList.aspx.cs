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
    public partial class AddressList : System.Web.UI.Page
    {
        private AddressRepository _addressRepository;
        public List<Address> Addresses { get; set; }

        public AddressList()
        {
            _addressRepository = new AddressRepository();
        }

        public AddressList(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        public void LoadAddressesFromDatabase(int customerId)
        {
            Addresses = _addressRepository.GetAllCustomerAdresses(customerId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdReq =Convert.ToInt32(Request.QueryString["customerId"]);
            LoadAddressesFromDatabase(customerIdReq);
        }

        public void OnClickAddAddress(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request.QueryString["customerId"]);
            Response.Redirect($"EditAddress.aspx?customerId={customerIdReq}");
        }
    }
}