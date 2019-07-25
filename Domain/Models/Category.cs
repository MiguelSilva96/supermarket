using System.Collections.Generic;
using Supermarket.API.Resources;

namespace Supermarket.API.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();

        public CategoryResource ToDto() {
            CategoryResource dto = new CategoryResource();
            dto.Id = this.Id;
            dto.Name = this.Name;
            return dto;
        }
    }
}