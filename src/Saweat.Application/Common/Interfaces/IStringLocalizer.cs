namespace Saweat.Application.Common.Interfaces;

public interface IStringLocalizer
{
    string this[string key] { get; }
}
