using SpaStore.Contracts;
using System.Web.Http;

namespace SpaStore.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ISpaStoreUow Uow { get; set; }
    }
}
