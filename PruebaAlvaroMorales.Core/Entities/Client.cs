using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Core.Entities
{
    public partial class Client
    {
        public string Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
