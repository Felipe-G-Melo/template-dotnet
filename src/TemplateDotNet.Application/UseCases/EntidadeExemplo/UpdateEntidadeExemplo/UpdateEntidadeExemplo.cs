using TemplateDotNet.Application.Interfaces;
using TemplateDotNet.Application.UseCases.EntidadeExemplo.Common;
using TemplateDotNet.Domain.Repositories;

namespace TemplateDotNet.Application.UseCases.EntidadeExemplo.UpdateEntidadeExemplo;
public class UpdateEntidadeExemplo : IUpdateEntidadeExemplo
{
    private readonly IEntidadeExemplo _entidadeExemploRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEntidadeExemplo(
        IEntidadeExemplo entidadeExemploRepository,
        IUnitOfWork unitOfWork
    )
    {
        _entidadeExemploRepository = entidadeExemploRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<EntidadeExemploOutput> Handle(UpdateEntidadeExemploInput input)
    {
        var entidade = await _entidadeExemploRepository.GetById(input.Id);
        entidade!.Update(
            input.Propriedade1,
            input.Propriedade2
            );

        await _unitOfWork.Commit();

        return EntidadeExemploOutput.FromOutput(entidade);
    }
}
