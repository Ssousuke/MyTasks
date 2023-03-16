using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTasks.Domain.Entities;

namespace MyTasks.Infra.EntityConfg
{
    public class MyTasksConfig : IEntityTypeConfiguration<MyTask>
    {
        public void Configure(EntityTypeBuilder<MyTask> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TaskName).HasMaxLength(75).IsRequired();
            builder.Property(x => x.TaskDescription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasOne(x => x.Projects)
                .WithMany(x => x.MyTasks)
                .HasForeignKey(x => x.ProjectId);
        }
    }
}
