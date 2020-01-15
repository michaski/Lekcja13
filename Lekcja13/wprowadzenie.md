# Lekcja 13

## 1. Wprowadzenie

W tej lekcji przedstawiony zostanie wzorzec **Builder (Budowniczy)** oraz **Factory (Fabryka)** a właściwie jego odmiany - **Factory method (metoda wytwórcza)**.

Odsyłam do [artykułu w Wikipedii](https://pl.wikipedia.org/wiki/Wzorzec_projektowy_(informatyka)), który może być punktem zaczepienia dla poznania historii powstania pojęcia wzorca projektowego w informatyce
 oraz podziałowi wzorców i reprezentantów poszczególnych grupy. Warto też wiedzieć kim byli członkowie **Gangu Czwarga (ang. Gang of Four, GoF)**.

## 2. Wzorzec Builder (budowniczy)

Wzorzec ten jest jednym z wzorców kreacyjnych. Stosowany jest po to aby przenieść sposób tworzenia obiektów z wielu przeciążonych kontruktorów na łacuch metod, budujących obiekt (nazywany kompozytem) element po elemncie.
We wzorcu **Builder**, który ma za zadanie zbudować finaly _produkt_, zgodnie z opisem przedstawionym przez GoF wystepuje jeszcze obiekt **kierownika, dyrektora lub nadzorcy**
zlecającego konstrukcję konkretnego produktu konkretnemu budowniczemu.
Jako przykład rozwiązania, które ma zaprezentowac sposób implementacji tego wzorca posłużymy się _"budowaniem"_ samochodów.
Pamiętajmy o ragułach SOLID i o tym, że zawsze staramy się zbudować jakieś ramy, interfejs i abstrakcję, która będzie mogła
być rozbudowana przez dodanie nowych implementacji (klas abstrakcyjnych, interfejsów) a nie poprzez modyfikację szkieletu aplikacji.

Tutaj elementami naszego szkieletu będzie głównie interfejs **IBuilder** (który jest składową wynikającą z samej definicji wzorca) oraz 
może być klasa Car, która będzie zapewniała spójne, ogólne cechy i zachowanie wszystkich samochodów.
Poniższy diagram powinien rzucić nieco więcej światła na omawiany wzorzec.
![Diagram dla naszego przypadku uzycia wzorca Builder](diagram_builder.png)

Warto wiedzieć, że implementacja wzorca Builder może przyjąć wiele postaci. Aktulanie omawiana postać nie zapewnia możliwości wykonania łańcuchowego budowania obiektu (np. Car.AddWheels().AddEngine()).
Takie podejście nazywane jest **statycznym budowniczym** i w takiej postaci jest często implementowany.
Potrzebni są jeszcze konkretni budowniczy, którzy będą wiedzieli jak zbudować konkretny model samochodu.
Poniżej przykładowa implementacja interfejsu budowniczego:

```csharp
public interface IBuilder
    {
        void AddSeats();
        void AddWheels();
        void AddEquipment();
        void AddEngine();
        Car GetCar();
    }
```
Tak może wyglądać implementacja **Nadzorcy**, który zleca przygotowanie konkretnego produktu:
```csharp
public class ProductionCheef
    {
        readonly IBuilder Builder;

        public Car BuildCar(IBuilder builder) {
            builder.AddEngine();
            builder.AddSeats();
            builder.AddWheels();
            builder.AddEquipment();

            return builder.GetCar();
        }
    }
```

Klasa Car, która jest naszym produktem:
```csharp
public abstract class Car
    {
        protected string Name;
        protected string Model;
        readonly string VIN;
        public string Wheels;
        public string Seats;
        public string Engine;
        public List<string> Equipment;
    }
```

I konkretny budowniczy:

```csharp
public class A4Builder : IBuilder
    {
        private Car car = new AudiA4();

        public void AddEngine()
        {
            car.Engine = "Klasyczny 136 konny Diesel";
        }

        public void AddEquipment()
        {
            car.Equipment = new List<string>();
            car.Equipment.Add("Standardowe radio CD");
            car.Equipment.Add("Lakier matowy, kolor biały");
        }

        public void AddSeats()
        {
            car.Seats = "Klasyczne fotele. Kolor szaro-czarny";
        }

        public void AddWheels()
        {
            car.Wheels = "16 calowe stalowe felgi. Opona 205/55 Continental.";
        }

        public Car GetCar()
        {
            return car;
        }
    }
```

## 3. Metoda wytwórcza (Factory method)


Metoda wytwórcza to odmiana wzorca Fabryka, która pozwala na stworzenie jednego punktu wejścia do tworzenia różnych 
obiektów konkretnych danego typu (najczęściej implementujących dany interfejs). 
Postanowiłem wykorzystać przykład zaprezentowany w artykule [na blogu wydawnictwa Helion](https://blog.helion.pl/wzorzec-projektowy-metoda-wytworcza/), który idelanie 
nadaje się do naszego przypadku użycia. Kod został zmieniony tak, aby była to prosta fabryka silników dla naszych 
budowniczych samochodów. Kod znajduje się w podfolderze **factory** w tej gałęzi repozytorium.
Szczególnie warte uwagi jest wykorzystanie słownika jako kontenera, który zwraca nowe instancje obiektów na 
podstawie parametru przekazanego do fabryki.

```csharp
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
```


