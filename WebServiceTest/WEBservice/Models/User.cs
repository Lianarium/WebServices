using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBservice
{
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public Adress Adress { get; set; }

        public string Geo;
        

        public string Phone { get; set; }

        public string WebSite { get; set; }

        public Company Company { get; set; }



    }
}
