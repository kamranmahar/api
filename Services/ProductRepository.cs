using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services.DapperHelpers;
using api.Services.Queries;
using System.Data.Common;
namespace api.Services
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public readonly ICommandText _commandText;
        public readonly IDapperHelper _dapperHelper;

        public ProductRepository(ICommandText commandText, DbConnection connection, IDapperHelper dapperHelper) : base(connection)
        {
            _commandText = commandText;
            _dapperHelper = dapperHelper;
        }


        public async Task<IEnumerable<Product>> GetAllProducts()
        {

            return await WithConnection(async conn =>
            {
                var query = await _dapperHelper.GetAllProducts<Product>(conn, _commandText.GetProducts);
                return query;
            });

        }

        public async ValueTask<Product> GetById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await _dapperHelper.GetById<Product>(conn, id, _commandText.GetProductById);
                return query;
            });

        }

        public async Task AddProduct(Product entity)
        {
            await WithConnection(async conn =>
            {
                await _dapperHelper.AddProduct(conn, entity, _commandText.AddProduct);
            });

        }
        public async Task UpdateProduct(Product entity, int id)
        {
            await WithConnection(async conn =>
            {
                await _dapperHelper.UpdateProduct(conn, entity, id, _commandText.UpdateProduct);
            });

        }

        public async Task RemoveProduct(int id)
        {

            await WithConnection(async conn =>
            {
                await _dapperHelper.RemoveProduct(conn, id, _commandText.RemoveProduct);
            });

        }
    }
}
