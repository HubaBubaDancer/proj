using System.Runtime.Serialization;

namespace proj.Models;

public class Provider : BaseDbItem
{
    public string CompanyName { get; set; }
    
    public string FiscalCode { get; set; }
    
    public string Address { get; set; }
    
    public string Email { get; set; }
    
    public string Number { get; set; }
}
