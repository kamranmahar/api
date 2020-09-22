using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using api.Services.DapperHelpers;
using api.Services.Queries;
using api.Services;
using api.Models;

namespace api.Services
{
    public class BrandRepository : BaseRepository, IBrandRepository
    {
        public readonly ICommandText _commandText;
        public readonly IDapperHelper _dapperHelper;
        public BrandRepository(ICommandText commandText, DbConnection connection, IDapperHelper dapperHelper) : base(connection)
        {
            _commandText = commandText;
            _dapperHelper = dapperHelper;
        }
        
        public async Task AddBrand(Brand entity)
        {
            await WithConnection(async conn =>
            {
                await _dapperHelper.AddBrand(conn, entity, _commandText.AddBrand);
            });

        }
        public async Task<IEnumerable<Brand>> GetAllBrand()
        {
            return await WithConnection(async conn =>
            {
                var query = await _dapperHelper.GetAllBrands<Brand>(conn, _commandText.GetBrands);
                return query;
            });
        }
       
        public async ValueTask<Brand> GetById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await _dapperHelper.GetBrandById<Brand>(conn, id, _commandText.GetBrandById);
                return query;
            });

        }

        public async Task RemoveBrand(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateBrand(Brand entity, int id)
        {
            await WithConnection(async conn =>
            {
                await _dapperHelper.UpdateBrand(conn, entity,id, _commandText.UpdateBrand);
            });

        }

    }
}
