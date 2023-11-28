using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.EntidadeExemplo.Common;

namespace TemplateDotNet.Application.UseCases.EntidadeExemplo.CreateEntidadeExemplo;
public interface ICreateEntidadeExemplo 
    : IHandler<CreateEntidadeExemploInput, EntidadeExemploOutput>
{
}
