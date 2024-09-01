using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Ironika_Theme1.Models
{
    public class Main
    {

        public RegisterClient ValidationRegister { get; set; }
        public Project ValidationProject { get; set; }
        public FirstRegister ValidationFirstRegister { get; set; }
        public ReWards ValidationReWards { get; set; }
        public Login ValidationClass { get; set; }

        public UserCopen ValidationCopen { get; set; }
        public Contact ValidationContact { get; set; }
        public People ValidationPeople { get; set; }
        public Review ValidationReview { get; set; }
        public Search ValidationSearch { get; set; }
        public Address ValidationAddress { get; set; }
        public AddressFa ValidationAddressFa { get; set; }
        public List<ClientOrder_Manager> BasketClass { get; set; }

    }


}