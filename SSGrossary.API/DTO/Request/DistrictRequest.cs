namespace SSGrossary.API.DTO.Request
{
    public class DistrictRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StateId {  get; set; }

        public int CountryId {  get; set; }
    }
}
