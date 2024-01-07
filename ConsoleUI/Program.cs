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

    var result = prdouctManager.GetProductDetails();

    if (result.Success)
    {
        foreach (var product in result.Data)
        {
            Console.WriteLine(product.ProductName + "/" + product.CategoryName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
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