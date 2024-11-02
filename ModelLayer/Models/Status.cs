namespace ModelLayer.Models;

public class Status
{
   public int Id { get; set; }
   public string StatusDescription { get; set; } = string.Empty;
   //Navigation Properties are used to reference the related entity 
   //It can be defined on the principal or dependent entity
   //public ICollection<User> Users { get; set; } = new List<User>(); //Collection navigation property
   
} 