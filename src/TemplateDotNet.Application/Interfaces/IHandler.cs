namespace TemplateDotNet.Application.Interfaces;
public interface IHandler<TInput, TOutput>
{
    Task<TOutput> Handle(TInput input);
}
