using System;

public interface IEngineFactory
{
    IEngine MakeEngine(string name);
}

public class EngineFactory : IEngineFactory
{
    private readonly Dictionary<string, IEngine> engines = new Dictionary<string, IEngine>()
    {
        { "diesel standard", new Diesel136HP() },
        { "diesel automat", new Diesel190HP() },
        { "benzyna biturbo", new Biturbo240HP() }
    };

    public IEngine MakeEngine(string name)
    {
        IEngine car;
        this.engines.TryGetValue(name, out engine);
        return engine;
    }
}
