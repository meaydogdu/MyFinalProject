// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//SOLID
//Open Closed Principle

//ProductTest();
CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

foreach(var category in categoryManager.GetAll())
{

    Console.WriteLine(category.CategoryName);
}
static void ProductTest()
{
    ProductManager prdouctManager = new ProductManager(new EfProductDal());

    foreach (var product in prdouctManager.GetAllByCategoryId(2))
    {
        Console.WriteLine(product.ProductName);
    }
}

