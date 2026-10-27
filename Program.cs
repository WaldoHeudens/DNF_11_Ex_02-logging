using _02_logging;
using Microsoft.Extensions.Logging;

// Maak een LoggerFactory met een console-provider. Buiten de Generic Host
// bouw je die zelf; de fabriek maakt daarna losse loggers aan.
using ILoggerFactory fabriek = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Information); // Trace en Debug worden weggefilterd
});

// De zes log-levels, van fijnmazig naar ernstig.
ILogger logger = fabriek.CreateLogger("Demo");
logger.LogTrace("Trace: zeer fijnmazige details");
logger.LogDebug("Debug: nuttig tijdens het ontwikkelen");
logger.LogInformation("Information: de normale gang van zaken");
logger.LogWarning("Warning: verdacht, maar nog geen fout");
logger.LogError("Error: een operatie is mislukt");
logger.LogCritical("Critical: de applicatie kan niet verder");

Console.WriteLine();

// Een service krijgt haar eigen ILogger<T> en logt onder haar categorie.
Weerdienst dienst = new(fabriek.CreateLogger<Weerdienst>());
dienst.HaalTemperatuurOp("Brussel");
dienst.HaalTemperatuurOp("Gent");
