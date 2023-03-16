using System.ComponentModel;

namespace MyTasks.Domain.Entities.Auxiliar.Enum
{
    public enum ProjectStep
    {
        [Description("Aguardando MyTaskse")]
        AGUARDANDO_MyTasksE = 0,

        [Description("Levantamento de requisitos")]
        LEVANTAMENTO_REQUISITOS = 1,

        [Description("Implementação")]
        IMPLEMENTACAO = 2,

        [Description("Testes")]
        TESTES = 3,

        [Description("Manutenção")]
        MANUTENCAO = 4,

        [Description("Finalizado")]
        FINALIZADO = 5,
    }
}
