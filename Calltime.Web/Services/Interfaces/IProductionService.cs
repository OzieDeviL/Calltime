using System.Collections.Generic;
using Calltime.Web.Domain;
using Calltime.Web.Models.Requests;

namespace Calltime.Web.Services.Interfaces
{
    public interface IProductionService
    {
        int DeleteById(int id);
        int Insert(ProductionPostPutRequest model);
        List<ProductionBase> SelectAll();
        ProductionBase SelectById(int id);
        int UpdateById(ProductionPostPutRequest model, int id);
    }
}