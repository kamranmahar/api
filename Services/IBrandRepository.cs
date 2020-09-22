using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services.DapperHelpers;

namespace api.Services
{
    public interface IBrandRepository
    {
        ValueTask<Brand> GetById(int id);
        Task AddBrand(Brand entity);
        Task UpdateBrand(Brand entity, int id);
        Task RemoveBrand(int id);
        Task<IEnumerable<Brand>> GetAllBrand();
    }
}
