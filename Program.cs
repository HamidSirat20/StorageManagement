// See https://aka.ms/new-console-template for more information
using StorageManagement.src.Domain;
using StorageManagement.src.Shared;

Console.WriteLine("Hello, World!");

Price price = new Price(12.4, Currency.Euro);

Product product1 = new Product(2, "Cheese", "This is cheese from greece", UnitEnum.PerBox, 4, price);
product1.IncreaseStock();
Price price1 = new Price() { ItemPrice = 12 };

product1.UseProduct(4);
System.Console.WriteLine(product1.ProductFullDescriptions());
product1.Print();



//product.ProductDetails();