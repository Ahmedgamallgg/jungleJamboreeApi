using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Services.Hepler
{
    public class Email
    {
      
        [EmailAddress]
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

       
        

    }
}
