namespace prjFinalProjectApi.Models.Dto
{
    public class SupplieslistDto
    {
        public int SuppliesProductID { get; set; }

        public string? SuppliesProductName { get; set; }

        public string? QuantityPerUnit { get; set; }

        public int? UnitsInStock { get; set; }

        public int? PricePerUnit { get; set; }

        public string? SuppliesSupplierName { get; set; }

        public string? SuppliesCategoryName { get; set; }

        public bool? Exist { get; set; }
    }
}
