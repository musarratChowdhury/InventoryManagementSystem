using System;
using System.Collections.Generic;
using System.Linq;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Dto.Product;
using IMS.BusinessModel.Entity;
using IMS.Dao;
using NHibernate;

namespace IMS.Services.SecondaryServices
{
    public class ProductService : BaseSecondaryService<Product>
    {
         private readonly IBaseDao<Product> _baseDao;
        public ProductService()
        {
            _baseDao = new BaseDao<Product>();
        }

        public List<ProductDto> GetAll(ISession session, DataRequest dataRequest)
        {
            try
            {
                var entities = _baseDao.GetAll(session, dataRequest);
                return (from t in entities let dto = new ProductDto() select MapToDto(t, dto)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Create(ProductFormDto productFormDto, long userId, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var product = new Product();
                    var mappedProduct = MapToEntity(productFormDto, product);
                    mappedProduct.Rank = GetNextRank(session);
                    mappedProduct.CreatedBy = userId;
                    mappedProduct.CreationDate = DateTime.Now;
                    _baseDao.Create(mappedProduct, session);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Update(ProductDto productDto, long modifiedById, ISession sess)
        {
            using (var transaction = sess.BeginTransaction())
            {
                try
                {
                    var product = new Product();
                    var mappedProduct = MapToEntity(productDto, product);
                    mappedProduct.ModificationDate = DateTime.Now;
                    mappedProduct.ModifiedBy = modifiedById;
                    
                    _baseDao.Update(mappedProduct, sess);
                    
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private ProductDto MapToDto(Product entity, ProductDto dto)
        {

            dto.Id = entity.Id;
            dto.ProductName = entity.ProductName;
            dto.ProductImageUrl = entity.ProductImageUrl;
            dto.ProductCategoryName = entity.ProductCategory.Name;
            dto.UnitOfMeasurementId = entity.UnitOfMeasurementId;
            dto.UnitOfMeasurementName = entity.UnitOfMeasurement.Name;
            dto.ProductCategoryId = entity.ProductCategoryId;
            dto.BuyingUnitPrice = entity.BuyingUnitPrice;
            dto.SellingUnitPrice = entity.SellingUnitPrice;
            dto.SKU = entity.SKU;
            dto.StockQuantity = entity.StockQuantity;
            dto.ManufacturingDate = entity.ManufacturingDate;
            dto.Status = entity.Status;
            dto.Rank = entity.Rank;
            dto.CreatedBy = entity.CreatedBy;
            dto.CreationDate = entity.CreationDate;
            dto.ModifiedBy = entity.ModifiedBy;
            dto.ModificationDate = entity.ModificationDate;
            dto.Version = entity.Version;
            dto.BusinessId = entity.BusinessId;

            return dto;
        }

        //for create operation
        private Product MapToEntity(ProductFormDto dto, Product product)
        {
            product.ProductName = dto.ProductName;
            product.ProductImageUrl = dto.ProductImageUrl;
            product.ProductCategoryId = dto.ProductCategoryId;
            product.UnitOfMeasurementId = dto.UnitOfMeasurementId;
            product.BuyingUnitPrice = dto.BuyingUnitPrice;
            product.SellingUnitPrice = dto.SellingUnitPrice;
            product.StockQuantity = dto.StockQuantity;
            product.SKU = dto.SKU;
            product.ManufacturingDate = dto.ManufacturingDate;
            product.Version = 1;
            product.BusinessId = "IMS-1";
            product.Status = 1;

            return product;
        }

        //for update action
        private Product MapToEntity(ProductDto dto, Product product)
        {
            product.Id = dto.Id;
            product.ProductName = dto.ProductName;
            product.ProductImageUrl = dto.ProductImageUrl;
            product.BuyingUnitPrice = dto.BuyingUnitPrice;
            product.SellingUnitPrice = dto.SellingUnitPrice;
            product.SKU = dto.SKU;
            product.StockQuantity = dto.StockQuantity;
            product.ManufacturingDate = dto.ManufacturingDate;
            product.CreatedBy = dto.CreatedBy;
            product.CreationDate = dto.CreationDate;
            product.ProductCategoryId = dto.ProductCategoryId;
            product.UnitOfMeasurementId = dto.UnitOfMeasurementId;
            product.Rank = dto.Rank;
            product.Version = 1;
            product.BusinessId = "IMS-1";
            product.Status = dto.Status;

            return product;
        }
    }
}