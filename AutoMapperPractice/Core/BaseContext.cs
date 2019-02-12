using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapperPractice.Map;

namespace AutoMapperPractice.Core
{
    public class BaseContext:DbContext
    {
        public BaseContext():base("name=Default")
        {
            Database.SetInitializer<BaseContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
