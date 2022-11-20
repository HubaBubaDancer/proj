namespace proj.Models;

public class DocumentModel : BaseDbItem 
{
    public string InvoiceNumber { get; set; }
    public Guid Provider { get; set; }
    public Guid Stock { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }
    public double Sum { get; set; }
    public DateTimeOffset DateTime { get; set; }
}