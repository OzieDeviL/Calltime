using Calltime.Web.Classes;
using Calltime.Web.Domain;
using Calltime.Web.Models.Requests;
using Calltime.Web.Models.Responses;
using Calltime.Web.Services;
using Calltime.Web.Services.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Calltime.Web.Controllers.Api
{
    [RoutePrefix("api/production")]
    public class ProductionApiController : BaseApiController
    {
        //ICrudService<ProductionBase, ProductionPostPutRequest> _crudService = null;
        //public ProductionApiController(
        //    crudService)
        //{
        //    _crudService = crudService;
        //}
        
        private ICrudService<ProductionBase, ProductionPostPutRequest> _productionSvc = null;
        //private IDomain _domain = null;
        ////private List<IDomain> _domainList = null;
        //private ItemsResponse<IDomain> _response = null;
        //private IRequestModel _requestModel = null;

        public ProductionApiController(
            [Dependency("ProductionSvc")] ICrudService<ProductionBase,ProductionPostPutRequest> productionSvc
            //, [Dependency("ProductionDomain")] IDomain domain
            //, [Dependency("ProductionDomainList")] List<IDomain> domainList
            //, [Dependency("ProductionResponse")] ItemsResponse<IDomain> response
            //, [Dependency("ProductionRequest")] IRequestModel requestModel
            )
        {
            this._productionSvc = productionSvc;
            //this._domain = domain;
            //this._domainList = domainList;
            //this._response = response;
            //this._requestModel = requestModel;
        }
        //IProductionService _productionSvc = null;

        //public ProductionApiController(IProductionService productionSvc)
        //{
        //    _productionSvc = productionSvc;
        //}

        [Route]
        [HttpPost]
        public HttpResponseMessage Post(ProductionPostPutRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            ItemResponse<int> response = new ItemResponse<int>();
            try
            {
              response.Item = _productionSvc.Insert(model);
            } catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route]
        [HttpGet]
        public HttpResponseMessage Get()
        {            
            ItemsResponse<ProductionBase> response = new ItemsResponse<ProductionBase>();
            response.Items = _productionSvc.SelectAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            if (id < 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid production id");
            }
            try
            {
                ItemResponse<IDomain> response = new ItemResponse<IDomain>();
                response.Item = _productionSvc.SelectById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                if (ex.Message == String.Format("No production with id {0} exists", id))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
        }

        [Route("{id:int}")]
        [HttpPut]
        public HttpResponseMessage Put(ProductionPostPutRequest model, int id)
        {
            if (id < 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid production id");
            }
            try
            {
                ItemResponse<string> response = new ItemResponse<string>();
                response.Item = String.Format("{0} rows affected", (_productionSvc.UpdateById(model, id)).ToString());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            } catch (Exception ex)
            {
                if (ex.Message == String.Format("No production with id {0} exists", id))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                } else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            if (id < 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid production id");
            }
            try
            {
                ItemResponse<string> response = new ItemResponse<string>();
                response.Item = String.Format("{0} rows affected", _productionSvc.DeleteById(id));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                if (ex.Message == String.Format("No production with id {0} exists", id))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                } else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }                
            }
        }
    }
}
