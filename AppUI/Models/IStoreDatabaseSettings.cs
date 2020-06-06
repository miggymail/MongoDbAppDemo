namespace AppUI.Models
{
    public interface IStoreDatabaseSettings
    {
        string ProductsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
