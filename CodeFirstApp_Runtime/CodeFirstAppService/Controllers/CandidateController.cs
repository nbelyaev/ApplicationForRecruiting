using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using CodeFirstAppService.DataObjects;
using CodeFirstAppService.Models;
using System;

namespace CodeFirstAppService.Controllers {
    public class CandidateController : TableController<Candidate> {
        protected override void Initialize(HttpControllerContext controllerContext) {
            base.Initialize(controllerContext);
            CodeFirstAppContext context = new CodeFirstAppContext();
            DomainManager = new EntityDomainManager<Candidate>(context, Request);
        }

        // GET tables/TodoItem
        public IQueryable<Candidate> GetCandidates() {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Candidate> GetCandidate(string id) {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Candidate> PatchCandidate(string id, Delta<Candidate> patch) {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostCandidate(Candidate item) {
            Candidate current = await InsertAsync(item);
            //current.CreatedAt = DateTime.Now;
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCandidate(string id) {
            return DeleteAsync(id);
        }
    }
}