using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSupport.Models.DTO
{
    public class ClientDTO
    {
        public int ReportNumber { get; set; }
        public string? NameClient { get; set; }
        public string? EmailClient { get; set; }
        public int? PhoneClient { get; set; }
        public string? Address { get; set; }
        public string? NameSecondContact { get; set; }
        public string? EmailSecondContact { get; set; }
        public int? PhoneSecondContact { get; set; }

        public ClientDTO() { }

        public static explicit operator ClientDTO(Task<ActionResult<IEnumerable<ClientDTO>>> v)
        {
            throw new NotImplementedException();
        }
    }
}
