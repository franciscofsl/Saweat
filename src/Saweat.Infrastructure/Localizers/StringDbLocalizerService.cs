using Microsoft.EntityFrameworkCore;
using Saweat.Application.Common.Interfaces;
using Saweat.Domain.Common;
using Saweat.Domain.Entities;
using System.Collections.Immutable;
using System.Globalization;

namespace Saweat.Infrastructure.Localizers;

public class StringDbLocalizerService : IStringLocalizer
{
    private readonly IReadOnlyRepository<Translate> _repository;
    private string _currentCulture = CultureInfo.CurrentCulture.Name;
    private ImmutableDictionary<string, string> _translates;
    
    public StringDbLocalizerService(IReadOnlyRepository<Translate> repository)
    {
        _repository = repository;
        InitializeTranslates().GetAwaiter().GetResult();
    }
    
    private async Task InitializeTranslates()
    {
        var query = await _repository.GetQueryableAsync();
        var translates = await query.Where(_ => _.Culture == _currentCulture).ToListAsync();
        
        _translates = translates.ToDictionary(_ => _.Key, _ => _.Value).ToImmutableDictionary();
    }  
    
    public string this[string key] => _translates.TryGetValue(key, out var value) ? value : key;
}