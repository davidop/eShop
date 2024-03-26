namespace Catalog.API.Model
{
    public class DalleResponse
    {
        public DalleResponse()
        {
            this.Value = new DalleItem();
        }

        public DalleItem Value { get; set; }
        public bool HasValue { get; set; }
    }
}
