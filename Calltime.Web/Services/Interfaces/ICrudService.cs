using Calltime.Web.Domain;
using Calltime.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calltime.Web.Services.Interfaces
{
    public interface ICrudService<T1, T2> 
    {
        int DeleteById(int id);
        int Insert(T2 model);
        List<T1> SelectAll();
        T1 SelectById(int id);
        int UpdateById(T2 model, int id);
    }
}