namespace TestWebAPI.Models;

public class Hero : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Hero(Guid id, string name)
    {
        Id = id;
        Name = name;
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
                new Hero(Guid.NewGuid(), "Dr. Nice"),
                new Hero(Guid.NewGuid(), "Bombasto"),
                new Hero(Guid.NewGuid(), "Celeritas"),
                new Hero(Guid.NewGuid(), "Magneta"),
                new Hero(Guid.NewGuid(), "RubberMan"),
                new Hero(Guid.NewGuid(), "Dynama"),
                new Hero(Guid.NewGuid(), "Dr. IQ"),
                new Hero(Guid.NewGuid(), "Magma"),
                new Hero(Guid.NewGuid(), "Tornado")
            };
            Heroes = heroesList;
        }

        return Heroes;
    }

    public static Hero AddHero(Hero hero)
    {
        var newHero = new Hero(Guid.NewGuid(), hero.Name);
        var heroes = Heroes.ToList();
        heroes.Add(newHero);
        Heroes = heroes;
        return Heroes.FirstOrDefault(h => h.Id == newHero.Id);
    }

    public static Hero UpdateHero(Hero hero)
    {
        if (!Heroes.Any() || Heroes is null)
            Heroes = GetHeroes();

        var updateHero = Heroes.FirstOrDefault(h => h.Id == hero.Id);

        if (updateHero is null)
            return null;

        updateHero.Name = hero.Name;

        return updateHero;
    }

    public static void DeleteHero(Guid id)
    {
        var hero = Heroes.FirstOrDefault(h => h.Id == id);

        if (hero is null)
            return;

        Heroes = Heroes.Where(h => h.Id != id);
    }
}