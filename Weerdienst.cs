namespace _02_logging;

using Microsoft.Extensions.Logging;

// Een service vraagt een ILogger<T> op via haar constructor. Het type T
// bepaalt de categorie waaronder de regels verschijnen (hier: Weerdienst).
public sealed class Weerdienst
{
    private readonly ILogger<Weerdienst> _logger;

    public Weerdienst(ILogger<Weerdienst> logger)
    {
        _logger = logger;
    }

    public int HaalTemperatuurOp(string stad)
    {
        // Waarden geef je als placeholder mee, niet met string-interpolatie.
        // Zo blijven ze apart beschikbaar voor gestructureerde logging.
        _logger.LogDebug("Temperatuur opvragen voor {Stad}", stad);

        int temperatuur = stad.Length * 3; // nep-berekening

        if (temperatuur > 20)
        {
            _logger.LogWarning("Hoge temperatuur voor {Stad}: {Temperatuur} graden", stad, temperatuur);
        }
        else
        {
            _logger.LogInformation("Temperatuur voor {Stad}: {Temperatuur} graden", stad, temperatuur);
        }

        return temperatuur;
    }
}
