// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//SOLID
//Open Closed Principle

ProductTest();
//Categorytest();
static void ProductTest()
{
    ProductManager prdouctManager = new ProductManager(new EfProductDal());

    foreach (var product in prdouctManager.GetProductDetails())
    {
        Console.WriteLine(product.ProductName+"/"+product.CategoryName);
    }
}

static void Categorytest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

    foreach (var category in categoryManager.GetAll())
    {

        Console.WriteLine(category.CategoryName);
    }
}