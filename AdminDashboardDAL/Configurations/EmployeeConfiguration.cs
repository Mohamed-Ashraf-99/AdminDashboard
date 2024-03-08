using AdminDashboardDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboardDAL.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .HasMaxLength(50);

            builder.Property(e => e.Email)
               .HasMaxLength(100);

            builder.Property(e => e.Notes)
               .HasMaxLength(500);

            builder.Property(e => e.Phone)
               .HasMaxLength(50);

            builder.Property(e => e.CreationDate)
                .HasDefaultValueSql("GETDATE()");


        }
    }
}
