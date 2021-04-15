using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodosWebApi.WebApi.Dtos
{
    public class TodoDto
    {
        public string Title { get; set; }
        public bool Completed { get; set; } = false;
    }
}
