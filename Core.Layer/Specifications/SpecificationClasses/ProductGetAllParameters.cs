namespace Core.Layer.Specifications.SpecificationClasses
{
    public class ProductGetAllParameters
    {
        public string? Sort {  get; set; }//nullable so it is not required parameter
        public int? BrandId { get; set; }//nullable so it is not required parameter
        public int? CategoryId { get; set; }//nullable so it is not required parameter
        public string? Search { get; set; }//nullable so it is not required parameter
        private const int max = 10;
        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value>10 ?10:value ; }
        }//the value =0 if no value (so this is initialization then it is not required parameter)
        public int PageIndex { get; set; } = 0; //initialization then it is not required parameter

    }
}
