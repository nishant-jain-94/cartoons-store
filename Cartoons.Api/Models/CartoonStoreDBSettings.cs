namespace Cartoons.Models
{
    public interface ICartoonStoreDBSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
    
    public class CartoonStoreDBSettings: ICartoonStoreDBSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDraftCartoonStoreDBSettings: ICartoonStoreDBSettings {}
    public class DraftCartoonStoreDBSettings: CartoonStoreDBSettings, IDraftCartoonStoreDBSettings {}

}