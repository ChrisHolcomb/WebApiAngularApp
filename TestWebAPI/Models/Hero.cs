namespace TestWebAPI.Models;

public class Hero
{
    public int id { get; set; }
    public string name { get; set; }

    public Hero(int Id, string Name)
    {
        id = Id;
        name = Name;
    }
}

public static class MockHeroes
{
    private static IEnumerable<Hero> Heroes { get; set; }
    public static IEnumerable<Hero> GetHeroes()
    {
        if (Heroes is null)
        {
            var heroesList = new List<Hero>
            {
                new Hero(12, "Dr. Nice"),
                new Hero(13, "Bombasto"),
                new Hero(14, "Celeritas"),
                new Hero(15, "Magneta"),
                new Hero(16, "RubberMan"),
                new Hero(17, "Dynama"),
                new Hero(18, "Dr. IQ"),
                new Hero(19, "Magma"),
                new Hero(20, "Tornado")
            };
            Heroes = heroesList;
        }

        return Heroes;
    }

    public static Hero AddHero(Hero hero)
    {
        var newHero = new Hero(Heroes.Max(h => h.id) + 1, hero.name);
        var heroes = Heroes.ToList();
        heroes.Add(newHero);
        Heroes = heroes;
        return Heroes.FirstOrDefault(h => h.id == newHero.id);
    }

    public static Hero UpdateHero(Hero hero)
    {
        if (!Heroes.Any() || Heroes is null)
            Heroes = GetHeroes();

        var updateHero = Heroes.FirstOrDefault(h => h.id == hero.id);

        if (updateHero is null)
            return null;

        updateHero.name = hero.name;

        return updateHero;
    }

    public static void DeleteHero(int id)
    {
        var hero = Heroes.FirstOrDefault(h => h.id == id);

        if (hero is null)
            return;

        Heroes = Heroes.Where(h => h.id != id);
    }
}