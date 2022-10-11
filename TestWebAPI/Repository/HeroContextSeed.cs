using MongoDB.Driver;
using TestWebAPI.Models;

namespace TestWebAPI.Repository;

public static class HeroContextSeed
{
    public static void SeedData(IMongoCollection<Hero> heroCollection)
    {
        var isHeroExist = heroCollection.Find(p => true).Any();
        if (!isHeroExist)
        {
            heroCollection.InsertManyAsync(GetInitialHeroes());
        }
    }

    private static List<Hero> GetInitialHeroes()
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

        return heroesList;
    }
}