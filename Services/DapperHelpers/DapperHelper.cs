using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using api.Models;

namespace api.Services.DapperHelpers
{
    public class DapperHelper : IDapperHelper
    {
        async Task<IEnumerable<T>> IDapperHelper.GetAllProducts<T>(IDbConnection connection, string commandText)
        {
            var query = await connection.QueryAsync<T>(commandText);
            return query;
        }

        async ValueTask<T> IDapperHelper.GetById<T>(IDbConnection connection, int id, string commandText)
        {
            var query = await connection.QueryFirstOrDefaultAsync<T>(commandText, new { Id = id });
            return query;
        }

        async Task IDapperHelper.AddProduct(IDbConnection connection, Product entity, string commandText)
        {
            await connection.ExecuteAsync(commandText,
                new { Name = entity.Name, Cost = entity.Price });
        }

        async Task IDapperHelper.UpdateProduct(IDbConnection connection, Product entity, int id, string commandText)
        {
            await connection.ExecuteAsync(commandText,
                new { Name = entity.Name, Cost = entity.Price, Id = id });
        }

        async Task IDapperHelper.RemoveProduct(IDbConnection connection, int id, string commandText)
        {
            await connection.ExecuteAsync(commandText, new { Id = id });
        }



        async Task<IEnumerable<T>> IDapperHelper.GetAllBrands<T>(IDbConnection connection, string commandText)
        {
            var query = await connection.QueryAsync<T>(commandText);
            return query;
        }

        async ValueTask<T> IDapperHelper.GetBrandById<T>(IDbConnection connection, int id, string commandText)
        {
            var query = await connection.QueryFirstOrDefaultAsync<T>(commandText, new { Id = id });
            return query;
        }

        async Task IDapperHelper.AddBrand(IDbConnection connection, Brand entity, string commandText)
        {
            await connection.ExecuteAsync(commandText,
                new { Name = entity.Name, Thumbnail = entity.Thumbnail, Description = entity.Description });
        }

        async Task IDapperHelper.UpdateBrand(IDbConnection connection, Brand entity, int id, string commandText)
        {
            await connection.ExecuteAsync(commandText,
                new { Name = entity.Name, Thumbnail = entity.Thumbnail, Description = entity.Description, BrandID = id });
        }

        async Task IDapperHelper.RemoveBrand(IDbConnection connection, int id, string commandText)
        {
            await connection.ExecuteAsync(commandText, new { BrandID = id });
        }

}

    }

