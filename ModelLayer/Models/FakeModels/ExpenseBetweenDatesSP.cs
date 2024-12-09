using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models.FakeModels;

public record ExpenseBetweenDatesSP
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string? UserName { get; set; }

    public string PaymentMethodName { get; set; } = string.Empty;

    public string BankName { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public DateTime ExpenseRegisterDate { get; set; }
}
