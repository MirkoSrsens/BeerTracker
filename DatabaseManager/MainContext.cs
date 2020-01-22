using DatabaseModels;
using System.Data.Entity;

public class MainContext : DbContext
{
    public DbSet<ProductionResponse> ProductionResponse { get; set; }
    public DbSet<ProductionSegmentResponse> ProductionSegmentResponse { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<NotificationMessage> NotificationMessages { get; set; }
    public DbSet<NotificationUser> NotificationUsers { get; set; }
    public DbSet<NotificationMessageUser> NotificationMessageUsers { get; set; }

    public MainContext()
        : base("name=defaultConnection")
    {

    }
}
