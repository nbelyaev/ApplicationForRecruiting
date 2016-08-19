using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using CodeFirstAppService.DataObjects;
using CodeFirstAppService.Models;

namespace CodeFirstAppService.Controllers {
    public class PositionController : TableController<Position> {
        protected override void Initialize(HttpControllerContext controllerContext) {
            base.Initialize(controllerContext);
            CodeFirstAppContext context = new CodeFirstAppContext();
            DomainManager = new EntityDomainManager<Position>(context, Request);
        }

        // GET tables/TodoItem
        public IQueryable<Position> GetAllCandidates() {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Position> GetCandidate(string id) {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Position> PatchCandidate(string id, Delta<Position> patch) {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostCandidate(Position item) {
            Position current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCandidate(string id) {
            return DeleteAsync(id);
        }
    }
}