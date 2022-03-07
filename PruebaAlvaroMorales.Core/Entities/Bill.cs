using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAlvaroMorales.Core.Entities
{
    public partial class Bill
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Clientid { get; set; }
        public string Total { get; set; }
        public string Subtotal { get; set; }
        public string Iva { get; set; }
        public string Retention { get; set; }
        public string CreationDate { get; set; }
        public string State { get; set; }
        public bool Paid { get; set; }
        public string PaymentDate { get; set; }
    }
}
