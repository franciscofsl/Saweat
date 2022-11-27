using FluentValidation.Results;

namespace Saweat.Application.Contracts.Common;

public sealed class CommandResult<TDto>
{
    private CommandResult()
    {

    }

    public static CommandResult<TDto> Successful(TDto attachedObject)
    {
        return new CommandResult<TDto>()
        {
            AttachedObject = attachedObject
        };
    }

    public static CommandResult<TDto> Invalid(List<ValidationFailure> errors)
    {
        return new CommandResult<TDto>()
        {
            Errors = errors.Select(_ => _.ErrorMessage).ToList().AsReadOnly()
        };
    }

    public TDto AttachedObject { get; private set; }

    public IReadOnlyCollection<string> Errors { get; private set; } = new List<string>().AsReadOnly();

    public bool IsValid => !Errors.Any();
}