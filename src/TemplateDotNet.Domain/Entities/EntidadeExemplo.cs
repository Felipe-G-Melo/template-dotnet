using TemplateDotNet.Domain.SeedWork;

namespace TemplateDotNet.Domain.Entities;
public class EntidadeExemplo : BaseEntity
{
    public string Propriedade1 { get; private set; }
    public string Propriedade2 { get; private set; }
    public int Propriedade3 { get; private set; }

    public EntidadeExemplo(string propriedade1, string propriedade2)
    {
        Propriedade1 = propriedade1;
        Propriedade2 = propriedade2;
        Validate();
    }

    public void Update(string propriedade1, string propriedade2)
    {
        Propriedade1 = propriedade1;
        Propriedade2 = propriedade2;
        UpdatedAt = DateTime.UtcNow;
        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(Propriedade1))
            throw new Exception("Propriedade1 is required");
        if (string.IsNullOrEmpty(Propriedade2))
            throw new Exception("Propriedade2 is required");
    }
}
