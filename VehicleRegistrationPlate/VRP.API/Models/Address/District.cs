namespace VRP.API.Models.Address
{
    public class District : BaseAddress
    {
        public int? CityId { get; set; }
        public virtual City? City { get; set; }
    }
}
