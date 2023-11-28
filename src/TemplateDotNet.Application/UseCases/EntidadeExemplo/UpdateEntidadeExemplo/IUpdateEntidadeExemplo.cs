using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.EntidadeExemplo.Common;

namespace TemplateDotNet.Application.UseCases.EntidadeExemplo.UpdateEntidadeExemplo;
public interface IUpdateEntidadeExemplo 
    : IHandler<UpdateEntidadeExemploInput, EntidadeExemploOutput>
{
}
