namespace proj.Models;

public class Product : BaseDbItem
{ 
    public Guid ProductsNom { get; set; }
    public float Amount { get; set; }
    public Guid Stock { get; set; }
}