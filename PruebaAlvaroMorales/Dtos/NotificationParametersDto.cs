using PruebaAlvaroMorales.Core.Entities;
using PruebaAlvaroMorales.Models;
using System.Collections.Generic;

namespace PruebaAlvaroMorales.Dtos
{
    public partial class NotificationParametersDto
    {
        public string ClientId { get; set; }
        public string BillId { get; set; }
    }
}
