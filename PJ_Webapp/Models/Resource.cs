using System.ComponentModel.DataAnnotations;

namespace PJ_Webapp.Models;

public class Resource
{
    [Key]
    public Guid resourceId { get; set; }
    public string name { get; set; }
    public int amount { get; set; }
    public ResourceCategory category { get; set; }

    public Resource()
    {
        
    }

    public Resource(string name, int amt, ResourceCategory category)
    {
        this.name = name;
        amount = amt;
        this.category = category;
    }
}