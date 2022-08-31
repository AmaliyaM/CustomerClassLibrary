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
    public partial class DeleteAddress : System.Web.UI.Page
    {
        private IRepository<Address> _addressRepository;
        public DeleteAddress()
        {
            _addressRepository = new AddressRepository();
        }

        public DeleteAddress(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdReq = Request.QueryString["customerId"];
            var address = new Address()
            {
                AddressId = Convert.ToInt32(Request.QueryString["id"]),
            };
            _addressRepository.Delete(address);
            Response.Redirect($"AddressList.aspx?customerId={customerIdReq}");

        }
    }
}