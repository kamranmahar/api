namespace api.Services.Queries
{
    public class CommandText : ICommandText
    {
        public string GetProducts => "Select * from Products";
        public string GetProductById => "Select * from Products where ID= @Id";
        public string AddProduct => "Insert into  [Products] (`Category_ID`, `Brand_ID`, `SKU`, `Name`, `ShortDescription`, `Description`, `Price`, `SalePrice`, `LinkID`, `CreatedDate`) values (@Category_ID, @Brand_ID, @SKU, @Name, @ShortDescription, @Description, @Price, @SalePrice, @LinkID, @CreatedDate)";
        public string UpdateProduct => "Update [Products] set `Category_ID` = @Category_ID, `Brand_ID` = @Brand_ID, `SKU` = @SKU, `Name` = @Name, `ShortDescription` = @ShortDescription, `Description` = @Description, `Price` = @Price, `SalePrice` = @SalePrice, `LinkID` = @LinkID , CreatedDate = GETDATE() where ID =@ID";
        public string RemoveProduct => "Delete from [Products] where ID= @ID";
        public string GetProductByIdSp => "GetProductId";

        public string GetBrands => "Select * from brands";
        public string GetBrandById => "Select * from Brands where Id= @Id";
        public string AddBrand => "Insert into  [Brands] ([Name], Cost, CreatedDate) values (@Name, @Cost, @CreatedDate)";
        public string UpdateBrand => "Update [Brands] set Name = @Name, Cost = @Cost, CreatedDate = GETDATE() where Id =@Id";
        public string RemoveBrand => "Delete from [Brands] where Id= @Id";
        public string GetBrandByIdSp => "GetBrandsId";

    }
}
