using System.ComponentModel;

namespace MyTasks.Domain.Entities.Auxiliar.Enum
{
    public enum ProjectStep
    {
        [Description("Em andamento")]
        EM_ANDAMENTO = 1,

        [Description("Implementação")]
        IMPLEMENTACAO = 2,

        [Description("Finalizado")]
        FINALIZADO = 3,
    }
}
