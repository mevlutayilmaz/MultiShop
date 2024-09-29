namespace MultiShop.Image.Settings
{
    public class StorageSettings
    {
        public StorageType Azure { get; set; }
    }

    public class StorageType
    {
        public string ConnectionString { get; set; }
        public string DomainUrl { get; set; }
    }
}
