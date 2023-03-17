using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTasks.Domain.Entities;
using MyTasks.Domain.Entities.Auxiliar.Enum;

namespace MyTasks.Infra.EntityConfg
{
    public class MyProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProjectName).HasMaxLength(75).IsRequired();
            builder.Property(x => x.ProjectDescription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.ProjectStep).HasDefaultValue(ProjectStep.AGUARDANDO_MyTasksE);
        }
    }
}
