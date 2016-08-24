using CodeFirstAppService.DataObjects;
using CodeFirstAppService.Models;
using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

namespace CodeFirstAppService.Controllers {
    public class CandidatePositionController : TableController<CandidatePosition> {
        protected override void Initialize(HttpControllerContext controllerContext) {
            base.Initialize(controllerContext);
            CodeFirstAppContext context = new CodeFirstAppContext();
            DomainManager = new EntityDomainManager<CandidatePosition>(context, Request);
        }

        // GET tables/TodoItem
        public IQueryable<CandidatePosition> GetCandidatePositions() {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CandidatePosition> GetCandidatePosition(string id) {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CandidatePosition> PatchCandidatePosition(string id, Delta<CandidatePosition> patch) {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostCandidatePosition(CandidatePosition item) {
            CandidatePosition current = await InsertAsync(item);
            //current.CreatedAt = DateTime.Now;
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCandidatePosition(string id) {
            return DeleteAsync(id);
        }
    }
}