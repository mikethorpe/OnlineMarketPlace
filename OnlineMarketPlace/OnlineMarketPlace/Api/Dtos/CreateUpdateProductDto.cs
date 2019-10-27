using System.ComponentModel.DataAnnotations;

namespace OnlineMarketPlace.Api.Dtos
{
    public class CreateUpdateProductDto
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
