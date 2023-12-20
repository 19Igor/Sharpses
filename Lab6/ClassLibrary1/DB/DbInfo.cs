namespace ClassLibrary1.DB;

public class DbInfo
{
    public int Index { get; set; }
    public ApplicationDbContext DB { get; set; }

    public DbInfo(ApplicationDbContext db, int index)
    {
        DB = db;
        Index = index;
    }
}