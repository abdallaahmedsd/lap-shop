using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Models
{
    class TbCheckOutInvoice
    {

        //Person Details..
        //Address Details..
        [Required]
        public int Id { get; set; }
        public int InvoiceId {  get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; }= null!;
        public string EmailAddress {  get; set; } = null!;

        public string Country { get; set; } = null!;

        public string ? City { get; set; } 
        public string ?State { get; set; }
        public string? postalCode {  get; set; } 



    }
}
