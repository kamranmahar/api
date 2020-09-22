namespace api.Services.Queries
{
    public interface ICommandText
    {
        string GetProducts { get; }
        string GetProductById { get; }
        string AddProduct { get; }
        string UpdateProduct { get; }
        string RemoveProduct { get; }


        string GetBrands { get; }
        string GetBrandById { get; }
        string AddBrand { get; }
        string UpdateBrand { get; }
        string RemoveBrand { get; }

    }
}
