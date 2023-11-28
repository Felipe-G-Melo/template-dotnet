namespace TemplateDotNet.Application.UseCases.EntidadeExemplo.CreateEntidadeExemplo;
public class CreateEntidadeExemploInput
{
    public string Propriedade1 { get; private set; }
    public string Propriedade2 { get; private set; }

    public CreateEntidadeExemploInput(string propriedade1, string propriedade2)
    {
        Propriedade1 = propriedade1;
        Propriedade2 = propriedade2;
    }
}
