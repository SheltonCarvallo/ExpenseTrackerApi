namespace ModelLayer.Models;

public class Status
{
   public int Id { get; set; }
   public string StatusDescription { get; set; } = string.Empty;
   //Navigation Properties are used to reference the related entity 
   //It can be defined on the principal or dependent entity
   public ICollection<User> Users { get;} = new List<User>(); //Collection navigation property
   public ICollection<PaymentMethod> PaymentMethods { get;} = new List<PaymentMethod>();
   public ICollection<Category> Categories { get; } = new List<Category>();
   public ICollection<Bank> Banks { get; } = new List<Bank>();
   public ICollection<Balance> Balances { get; } = new List<Balance>();
   public ICollection<Expense> Expenses { get; } = new List<Expense>();
} 