using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTasks.Domain;

namespace MyTasks.Persistence.EntityTypeConfigurations
{
    public class MyTaskConfiguration : IEntityTypeConfiguration<MyTask>
    {
        public void Configure(EntityTypeBuilder<MyTask> builder)
        {
            builder.HasKey(task => task.Id);
            builder.HasIndex(task => task.Id).IsUnique();
            builder.Property(task => task.Type).HasConversion<string>().IsRequired();
            builder.Property(task => task.Description).HasMaxLength(300).IsRequired();
            builder.Property(task => task.CompletedDate).IsRequired();
            builder.Property(task => task.IsCompleted).HasConversion<string>().IsRequired();
        }
    }
}
