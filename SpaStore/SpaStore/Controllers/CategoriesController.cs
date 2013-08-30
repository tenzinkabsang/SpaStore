using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpaStore.Contracts;
using SpaStore.Model;

namespace SpaStore.Controllers
{
    public class CategoriesController: ApiControllerBase
    {
        public CategoriesController(ISpaStoreUow uow)
        {
            Uow = uow;
        }

        // GET: /api/categories
        public IEnumerable<Category> Get()
        {
            return Uow.Categories.GetAll()
                      .OrderBy(c => c.Name);
        }

        // GET: /api/categories/4
        public Category Get(int id)
        {
            Category category = Uow.Categories.GetById(id);
            if (category != null)
                return category;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // PUT: /api/categories
        public HttpResponseMessage Put(Category category)
        {
            Uow.Categories.Update(category);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // POST: /api/categories
        public HttpResponseMessage Post(Category category)
        {
            Uow.Categories.Add(category);
            Uow.Commit();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = category.Id }));
            return response;
        }


    }
}