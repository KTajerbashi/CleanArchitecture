using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;
using System.Globalization;

namespace CleanArchitecture.Core.Application.Library.Providers.Translator;

public interface ITranslator
{
    string this[string name] { get; set; }
    string this[CultureInfo culture, string name] { get; set; }

    string this[string name, params string[] arguments] { get; set; }
    string this[CultureInfo culture, string name, params string[] arguments] { get; set; }

    string this[char separator, params string[] names] { get; set; }
    string this[CultureInfo culture, char separator, params string[] names] { get; set; }

    string GetString(string name);
    string GetString(CultureInfo culture, string name);

    string GetString(string pattern, params string[] arguments);
    string GetString(CultureInfo culture, string pattern, params string[] arguments);

    string GetConcateString(char separator = ' ', params string[] names);
    string GetConcateString(CultureInfo culture, char separator = ' ', params string[] names);

}



