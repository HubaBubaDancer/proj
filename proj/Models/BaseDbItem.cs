namespace proj.Models;

public class BaseDbItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
}