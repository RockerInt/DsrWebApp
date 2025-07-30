using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Entities;

namespace WebApp.Infrastructure;

public static class DataSeeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var clientId1 = new Guid("1a8a7e4a-72db-4c51-8a6a-3a3a3a3a3a3a");
        var clientId2 = new Guid("2b8b8f5b-83ec-5d62-9b7b-4b4b4b4b4b4b");
        var productId1 = new Guid("3c9c9c6c-94fd-4e73-ac8c-5c5c5c5c5c5c");
        var productId2 = new Guid("4d0d0d7d-05de-4f84-bd9d-6d6d6d6d6d6d");
        var saleId = new Guid("5e1e1e8e-16df-4a95-ce0e-7e7e7e7e7e7e");

        modelBuilder.Entity<Client>().HasData(
            new Client("John Doe", "john.doe@example.com", "+57 3123456789", clientId1) { CreateDate = new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)},
            new Client("Jane Smith", "jane.smith@example.com", "+57 3212345678", clientId2) { CreateDate = new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product("Laptop", "Personal computer macbook", 1200, productId1) { CreateDate = new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }, 
            new Product("Mouse", "Computer mouse", 25, productId2) { CreateDate = new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
        );

        modelBuilder.Entity<Inventory>().HasData(
            new Inventory(productId1, 10) { CreateDate = new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Inventory(productId2, 50) { CreateDate = new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
        );

        modelBuilder.Entity<Sale>().HasData(
            new Sale(clientId1, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), [], saleId) { CreateDate = new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
        );

        modelBuilder.Entity<SaleItem>().HasData(
            new SaleItem(productId1, 1, 1200, new Guid("6f2f2f9f-27fa-4c06-df1f-8f8f8f8f8f8f"), saleId) { CreateDate = new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new SaleItem(productId2, 1, 25, new Guid("7a3a3c0a-38ab-4e17-ea2a-9a9a9a9a9a9a"), saleId) { CreateDate = new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
        );
    }
}
