using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppShop.Models;

namespace WebAppShop.ModelsView
{
    public class NewCustomerModelView
    {
        //public List<MembershipType> MembershipTypes { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}