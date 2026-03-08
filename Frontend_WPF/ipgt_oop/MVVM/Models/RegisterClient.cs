using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ipgt_oop.MVVM.Models
{
    internal class RegisterClient
    {

        public string name { get; set; }
        public string email { get; set; }

        public string password { get; set; }

        public string nif { get; set; }

        public string country { get; set; }

        public string image { get; set; }

    }
}
