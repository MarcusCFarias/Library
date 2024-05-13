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
    internal class BookLoanConfiguration : BaseEntityConfiguration<BookLoan>
    {
        public override void Configure(EntityTypeBuilder<BookLoan> builder)
        {
            base.Configure(builder);

            builder.ToTable("BookLoan");

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

            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookLoans)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                .WithMany(x => x.BookLoans)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
