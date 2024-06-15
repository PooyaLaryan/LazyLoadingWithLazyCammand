// See https://aka.ms/new-console-template for more information

using LazyLoadingWithLazyCammand;

Customer customer = new();

Console.WriteLine(customer.IsValueCreated);

foreach (var item in customer.GetOrders)
{
    Console.WriteLine(item.Id);
}

Console.WriteLine(customer.IsValueCreated);
