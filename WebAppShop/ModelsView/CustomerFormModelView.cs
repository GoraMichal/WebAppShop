using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppShop.Models;

namespace WebAppShop.ModelsView
{
    public class CustomerFormModelView
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Edytuj użytkownika";
                return "Nowy użytkownik";
            }
        }
    }
}