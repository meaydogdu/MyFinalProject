using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IproductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            #region notlar
            
            //Validation
            //Business rules(Alesten 70 amış mı , kredi için puani yeterli mi vs) ve Dogrulama kodlari(minimum bu kadar karekter olmalı vs) ayri değerlendirilmeli

            //if (product.UnitPrice <= 0)
            //{
            //    return new ErrorDataResult();
            //}

            //if (product.ProductName.Length < 2)
            //{
            //    //magic strings
            //    //return new ErrorResult("Ürün ismi uygun değildir."); 
            //    //Refactoring;
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            //yukaridaki kontroller Productvalidatora tasidik.

            //var context = new ValidationContext<Product>(product);
            //ProductValidator p = new ProductValidator();
            //var result = p.Validate(product);

            //if (!result.IsValid)
            //{
            //    throw new FluentValidation.ValidationException(result.Errors);
            //}
            //

            //Yukarıdaki yapıyı Core.CrossCuttingConcersns.Validation.Valitatora taşıdık

            //Loglama
            //cacheremover
            //performance
            //transaction
            //yetkilendirme

            //business codes  burada istemiyoruz. 

            //return new SuccessResult("Ürün Eklendi");
            //Refactoring;
            // ValidationTool.Validate(new ProductValidator(), product);
            #endregion


            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş Kodları
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new DataResult<List<Product>>(_productDal.GetAll(), true, Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
