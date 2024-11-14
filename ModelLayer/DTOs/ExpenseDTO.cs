using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTOs
{
    public class ExpenseDTO
    {
        public Guid ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public string? UserName { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Bank { get; set; }
        public string? Category {  get; set; }
        public DateTime RegisterDate{ get; set; }
        

    }
}
