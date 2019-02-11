using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapperPractice.Model.Entity;

namespace AutoMapperPractice.Map
{
    public class EmployeeMap:EntityTypeConfiguration<EmployeeEntity>
    {
        public EmployeeMap()
        {
            ToTable("Employee");
            HasKey(s => s.Id);
            Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(s => s.FirstName).HasMaxLength(20);
            Property(s => s.LastName).HasMaxLength(20);
        }
    }
}
