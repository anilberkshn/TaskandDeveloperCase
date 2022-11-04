namespace Case2GK20221102.Entities;

public class Task : Document
{
    
    public string Title { get; set; }
    public string Description { get; set; }
    public int Department { get; set; }
    public Guid DeveloperId { get; set; }
    public int Status { get; set; }
}