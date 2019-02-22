using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapperPractice.Attributes;

namespace AutoMapperPractice.Model.AttributesModel
{
    [AutoMap(typeof(MenuEntity))]
    public class MenuDto
    {
        public int Id { get; set; }

        public string MenuName { get; set; }
        public string MenuCode { get; set; }
    }
}
