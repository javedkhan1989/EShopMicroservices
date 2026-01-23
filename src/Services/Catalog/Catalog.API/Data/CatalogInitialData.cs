using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            //MARTEN UPSERT will carter for existing records
            session.Store<Product>(GetProductConfigureProduct());
            await session.SaveChangesAsync(cancellation);

        }

        

        private static IEnumerable<Product> GetProductConfigureProduct() => new List<Product> {

         new Product
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Laptop Pro 15",
            Category = new List<string> { "Electronics", "Computers" },
            Description = "High performance laptop for professionals",
            ImageFile = "laptop-pro-15.png",
            Price = 125000
        },
        new Product
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Wireless Mouse",
            Category = new List<string> { "Electronics", "Accessories" },
            Description = "Ergonomic wireless mouse",
            ImageFile = "wireless-mouse.png",
            Price = 1499
        },
        new Product
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Name = "Mechanical Keyboard",
            Category = new List<string> { "Electronics", "Accessories" },
            Description = "RGB mechanical keyboard",
            ImageFile = "mechanical-keyboard.png",
            Price = 5999
        },
        new Product
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            Name = "Smartphone X",
            Category = new List<string> { "Electronics", "Mobile" },
            Description = "Latest generation smartphone",
            ImageFile = "smartphone-x.png",
            Price = 79999
        },
        new Product
        {
            Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
            Name = "Bluetooth Headphones",
            Category = new List<string> { "Electronics", "Audio" },
            Description = "Noise cancelling headphones",
            ImageFile = "bluetooth-headphones.png",
            Price = 8999
        },
        new Product
        {
            Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
            Name = "Smart Watch",
            Category = new List<string> { "Electronics", "Wearable" },
            Description = "Fitness tracking smart watch",
            ImageFile = "smart-watch.png",
            Price = 15999
        },
        new Product
        {
            Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
            Name = "Tablet Plus",
            Category = new List<string> { "Electronics", "Tablet" },
            Description = "10-inch display tablet",
            ImageFile = "tablet-plus.png",
            Price = 34999
        },
        new Product
        {
            Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
            Name = "External Hard Drive",
            Category = new List<string> { "Electronics", "Storage" },
            Description = "1TB portable hard drive",
            ImageFile = "external-hdd.png",
            Price = 5499
        },
        new Product
        {
            Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
            Name = "Gaming Monitor",
            Category = new List<string> { "Electronics", "Gaming" },
            Description = "144Hz gaming monitor",
            ImageFile = "gaming-monitor.png",
            Price = 27999
        },
        new Product
        {
            Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
            Name = "USB-C Hub",
            Category = new List<string> { "Electronics", "Accessories" },
            Description = "Multiport USB-C hub",
            ImageFile = "usb-c-hub.png",
            Price = 2999
        }

    };
}
}
