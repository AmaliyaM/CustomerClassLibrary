using CustomerInformation;
using CustomerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerLibrary.WebForms
{
    public partial class EditAddress : System.Web.UI.Page
    {

        private AddressRepository _addressRepository;
        public List<Address> Addresses { get; set; }

        public EditAddress()
        {
            _addressRepository = new AddressRepository();
        }

        public EditAddress(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var addressIdReq = Request.QueryString["id"]; 
                if (addressIdReq != null)
                {
                    var address = _addressRepository.Read(addressIdReq);

                    firstLine.Text = address.FirstLine;
                    secondLine.Text = address.SecondLine;
                    addressType.Text = address.Type.ToString();
                    city.Text = address.City;
                    postalCode.Text = address.PostalCode;
                    state.Text = address.State;
                    country.Text = address.Country.ToString();
                }
            }

        }

        public void OnClickSave(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request.QueryString["customerId"]);
            var addressIdReq = Convert.ToInt32(Request.QueryString["id"]);
            AddressType resultType;
            AvailableCountries resultCountry;
            Enum.TryParse<AddressType>(addressType?.Text.ToString(), out resultType);
            Enum.TryParse<AvailableCountries>(country?.Text.ToString(), out resultCountry);
            var address = new Address()
            {
                FirstLine = firstLine?.Text,
                SecondLine = secondLine?.Text,
                Type = resultType,
                City = city?.Text,
                PostalCode = postalCode?.Text,
                State = state?.Text,
                Country = resultCountry,
                CustomerId = customerIdReq,
                AddressId = addressIdReq
            };
            if (Request.QueryString["id"] == null)
                _addressRepository.Create(address);
            else _addressRepository.Update(address);

            Response.Redirect($"AddressList.aspx?customerId={customerIdReq}");

        }
    }
}