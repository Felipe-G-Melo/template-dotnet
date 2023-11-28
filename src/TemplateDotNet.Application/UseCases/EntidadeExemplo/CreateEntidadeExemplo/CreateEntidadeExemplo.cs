using TemplateDotNet.Application.Interfaces;
using Entity = TemplateDotNet.Domain.Entities;
using TemplateDotNet.Domain.Repositories;
using TemplateDotNet.Application.UseCases.EntidadeExemplo.Common;

namespace TemplateDotNet.Application.UseCases.EntidadeExemplo.CreateEntidadeExemplo;
public class CreateEntidadeExemplo : ICreateEntidadeExemplo
{
    private readonly IEntidadeExemplo _entidadeExemploRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEntidadeExemplo(
        IEntidadeExemplo entidadeExemploRepository,
        IUnitOfWork unitOfWork
    )
    {
        _entidadeExemploRepository = entidadeExemploRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<EntidadeExemploOutput> Handle(CreateEntidadeExemploInput input)
    {
        var entity = new Entity.EntidadeExemplo(
            input.Propriedade1,
            input.Propriedade2
            );
        await _entidadeExemploRepository.Insert(entity);
        await _unitOfWork.Commit();

        return EntidadeExemploOutput.FromOutput(entity);
    }
}
