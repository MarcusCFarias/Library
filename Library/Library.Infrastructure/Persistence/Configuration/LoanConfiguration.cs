using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Configuration
{
    internal class LoanConfiguration : BaseEntityConfiguration<Loan>
    {
        public override void Configure(EntityTypeBuilder<Loan> builder)
        {
            base.Configure(builder);

            builder.ToTable("Loan");

            builder.Property(p => p.StartDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.EndDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.ReturnDate)
                .HasColumnType("date")
                .IsRequired(false);

            builder.Property(p => p.Fine)
                .HasColumnType("decimal(18,2)")
                .IsRequired(false);

            builder.HasOne<Book>()
                .WithMany()
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
