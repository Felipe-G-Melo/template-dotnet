namespace TemplateDotNet.Infra.Data.EF.Exceptions;
public class NotNullException
{
    public static void VerifyIfThisIsNull(dynamic? entity, string message)
    {
        if (entity is null)
            throw new Exception(message);
    }
}
