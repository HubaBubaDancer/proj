namespace proj.Models;

public class InComingModel : BaseDbItem
{
    public DateTimeOffset CreatedTime { get; set; }
    
    public IEnumerable<Product> Products { get; set; }
}