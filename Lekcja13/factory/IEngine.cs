using System;

public interface IEngine
{
	string GetDescription();
}

public class Diesel136HP : IEngine
{
    public string GetDescription()
    {
        return "Klasyczny Diesel 136 Koni";
    }
}

public class Diesel190HP : IEngine
{
    public string GetDescription()
    {
        return "Diesel do wersji A4 i A6 automat";
    }
}

public class BiTurbo240HP : IEngine
{
    public string GetDescription()
    {
        return "Benzynowa rakieta!";
    }
}
