using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using api.Models;

namespace api.Services.DapperHelpers
{
    public interface IDapperHelper
    {
        Task<IEnumerable<T>> GetAllProducts<T>(IDbConnection connection, string commandText);
        ValueTask<T> GetById<T>(IDbConnection connection, int id, string commandText);
        Task AddProduct(IDbConnection connection, Product entity, string commandText);
        Task UpdateProduct(IDbConnection connection, Product entity, int id, string commandText);
        Task RemoveProduct(IDbConnection connection, int id, string commandText);


        Task<IEnumerable<T>> GetAllBrands<T>(IDbConnection connection, string commandText);
        ValueTask<T> GetBrandById<T>(IDbConnection connection, int id, string commandText);
        Task AddBrand(IDbConnection connection, Brand entity, string commandText);
        Task UpdateBrand(IDbConnection connection, Brand entity, int id, string commandText);
        Task RemoveBrand(IDbConnection connection, int id, string commandText);

    }
}
