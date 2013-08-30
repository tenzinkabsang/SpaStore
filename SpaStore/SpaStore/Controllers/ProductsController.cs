﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpaStore.Contracts;
using SpaStore.Model;

namespace SpaStore.Controllers
{
    public class ProductsController: ApiControllerBase
    {
       public ProductsController(ISpaStoreUow uow)
       {
           base.Uow = uow;
       }

        // GET: /api/products
        public IEnumerable<ProductDto> Get()
        {
            var products = Uow.Products.GetProductDtos()
                      .OrderBy(p => p.Id).ToList();

            return products;
        }

        // GET: /api/products/5
        public Product Get(int id)
        {
            var product = Uow.Products.GetById(id);
            if (product != null)
                return product;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // GET: /api/products/getByCategoryId/4
        public IEnumerable<Product> GetByCategoryId(int id)
        {
            return Uow.Products.GetAll()
                      .Where(p => p.CategoryId == id);
        }

        // Update an existing Product
        // PUT: /api/products
        public HttpResponseMessage Put(Product product)
        {
            Uow.Products.Update(product);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // Create a new Product
        // POST: /api/products
        public HttpResponseMessage Post(Product product)
        {
            Uow.Products.Add(product);
            Uow.Commit();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

            // Compose location header that tells how to get this product e.g. ~/api/products/3
            response.Headers.Location = new Uri(Url.Link(WebApiConfig.ControllerAndId, new{ Id = product.Id}));
            return response;
        }

        // DELETE: /api/products/4
        public HttpResponseMessage Delete(int id)
        {
            Uow.Products.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        //: OData Future
        //[Queryable]
        //public IQueryable<Product> Get() 
    }
}