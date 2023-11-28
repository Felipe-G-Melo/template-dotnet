using Entity = TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Application.UseCases.EntidadeExemplo.Common;
public class EntidadeExemploOutput
{
    public string Propriedade1 { get; private set; }
    public string Propriedade2 { get; private set; }
    public int Propriedade3 { get; private set; }

    public EntidadeExemploOutput(
        string propriedade1,
        string propriedade2,
        int propriedade3
    )
    {
        Propriedade1 = propriedade1;
        Propriedade2 = propriedade2;
        Propriedade3 = propriedade3;
    }

    public static EntidadeExemploOutput FromOutput(Entity.EntidadeExemplo entidadeExemplo)
        => new(
            entidadeExemplo.Propriedade1,
            entidadeExemplo.Propriedade2,
            entidadeExemplo.Propriedade3
            );
}
