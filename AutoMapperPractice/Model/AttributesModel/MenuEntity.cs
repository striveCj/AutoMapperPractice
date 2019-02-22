using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Model.AttributesModel
{
    public class MenuEntity
    {
        public int Id { get; set; }
        public string MenuName { get; set; }

        public string MenuCode { get; set; }
        public string ParentCode { get; set; }

        public int ParentId { get; set; }
    }
}
