using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SQLServer.EF.Configuration.CommentConfigs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .IsRequired();

            builder.Property(x => x.Score)
                   .HasColumnType("decimal(3, 2)");

            builder.HasOne(x => x.Customer)
           .WithMany(x => x.Comments)
           .HasForeignKey(x => x.CustomerId)
           .OnDelete(DeleteBehavior.NoAction); 

            builder.HasOne(x=>x.Expert)
                .WithMany(x => x.Comments)
                .HasForeignKey(x=>x.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
