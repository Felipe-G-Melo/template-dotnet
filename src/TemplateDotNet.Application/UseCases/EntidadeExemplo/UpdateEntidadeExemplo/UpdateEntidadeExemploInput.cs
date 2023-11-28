namespace TemplateDotNet.Application.UseCases.EntidadeExemplo.UpdateEntidadeExemplo;
public class UpdateEntidadeExemploInput
{
    public Guid Id { get; private set; }
    public string Propriedade1 { get; private set; }
    public string Propriedade2 { get; private set; }

    public UpdateEntidadeExemploInput(
        Guid id,
        string propriedade1,
        string propriedade2
    )
    {
        Id = id;
        Propriedade1 = propriedade1;
        Propriedade2 = propriedade2;
    }
}