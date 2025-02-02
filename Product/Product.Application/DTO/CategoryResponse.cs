using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.DTO
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
