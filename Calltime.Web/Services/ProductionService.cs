using Calltime.Web.Domain;
using Calltime.Web.Models.Requests;
using Calltime.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WikiDataProvider.Data.Extensions;

namespace Calltime.Web.Services
{
    public class ProductionService : BaseService, IProductionService, ICrudService<ProductionBase, ProductionPostPutRequest>
    {
        public int Insert(ProductionPostPutRequest model)
        {
            int InsertedProductionId = 0;
            DataProvider.ExecuteNonQuery(GetConnection
                , "dbo.Production_Insert"
                , inputParamMapper: delegate (SqlParameterCollection sqlParams)
                    {
                        ProductionInputMapper(model, sqlParams);
                        SqlParameter p = new SqlParameter("@Id", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;
                        sqlParams.Add(p);
                    }
                , returnParameters: delegate (SqlParameterCollection param)
                    {
                        int.TryParse(param["@Id"].Value.ToString(), out InsertedProductionId);
                    }
                );
            return InsertedProductionId;
        }

        public List<ProductionBase> SelectAll()
        {
            List<ProductionBase> productions = null;
            DataProvider.ExecuteCmd(GetConnection
                , "dbo.Production_Select_All"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                {
                    ProductionBase p = ProductionOutputMapper(reader);
                    if (productions == null)
                    {
                        productions = new List<ProductionBase>();
                    }
                    productions.Add(p);
                }
                );
            return productions;
        }

        public ProductionBase SelectById(int id)
        {
            ProductionBase production = null;
            bool nullResult = true;
            DataProvider.ExecuteCmd(GetConnection
                , "dbo.Production_Select_ById"
                , inputParamMapper: delegate (SqlParameterCollection sqlParams)
                {
                    sqlParams.AddWithValue("@Id", id);
                }
                , map: delegate (IDataReader reader, short set)
                {
                    nullResult = false;
                    production = ProductionOutputMapper(reader);
                }
                );
            if (nullResult == true)
            {
                throw new Exception(String.Format("No production with id {0} exists", id));
            }
            return production;
        }

        public int UpdateById(ProductionPostPutRequest model, int id)
        {
            int rowsAffected = -1;
            DataProvider.ExecuteNonQuery(GetConnection
                , "dbo.Production_Update_ById"
                , inputParamMapper: delegate (SqlParameterCollection sqlParams)
                {
                    ProductionInputMapper(model, sqlParams);
                    sqlParams.AddWithValue("@ProductionId", id);
                    SqlParameter p = new SqlParameter("@RowsAffected", rowsAffected);
                    p.Direction = ParameterDirection.Output;
                    sqlParams.Add(p);
                }
                , returnParameters: delegate (SqlParameterCollection sqlParams)
                {
                    int.TryParse(sqlParams["@RowsAffected"].Value.ToString(), out rowsAffected);
                }
                );
            if (rowsAffected == 0)
            {
                throw new Exception(String.Format("No production with id {0} exists.", id));                    
            }
            return rowsAffected;
        }

        public int DeleteById(int id)
        {
            int rowsAffected = -1;
            DataProvider.ExecuteNonQuery(GetConnection
                , "dbo.Production_Delete_ById"
                , inputParamMapper: delegate (SqlParameterCollection sqlParams)
                {
                    sqlParams.AddWithValue("@Id", id);
                    SqlParameter p = new SqlParameter("@RowsAffected", rowsAffected);
                    p.Direction = ParameterDirection.Output;
                    sqlParams.Add(p);
                }
                , returnParameters: delegate (SqlParameterCollection sqlParams)
                {
                  int.TryParse(sqlParams["@RowsAffected"].Value.ToString(), out rowsAffected);
                }
                );
            if (rowsAffected == 0)
            {
                throw new Exception(String.Format("No production with id {0} exists", id));
            }
            return rowsAffected;
        }

        #region private methods
        private void ProductionInputMapper(ProductionPostPutRequest model, SqlParameterCollection sqlParams)
        {
            sqlParams.AddWithValue("@PersonId", model.PersonId);
            sqlParams.AddWithValue("@ProductionName", model.ProductionName);
            sqlParams.AddWithValue("@LongName", model.LongName);
            sqlParams.AddWithValue("@CodeName", model.CodeName);
        }

        private ProductionBase ProductionOutputMapper(IDataReader reader)
        {
            ProductionBase p = new ProductionBase();
            int i = 0;
            p.Id = reader.GetSafeInt32(i++);
            p.ProductionName = reader.GetSafeString(i++);
            p.LongName = reader.GetSafeString(i++);
            p.CodeName = reader.GetSafeString(i++);
            return p;
        }
        #endregion
    }
}