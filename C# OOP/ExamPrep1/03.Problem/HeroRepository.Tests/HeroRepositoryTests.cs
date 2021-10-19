using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository repo;

    [SetUp]
    public void SetUp()
    {
        this.repo = new HeroRepository();
        this.hero = new Hero("Stefan", 9);
    }

    [Test]
    public void CreateHero_Throws_ExceptionNullHero()
    {
        Hero hero = null;
        Assert.Throws<ArgumentNullException>(() => repo.Create(hero));
    }
    [Test]
    public void CreateHero_Throws_Exception_ForExistingName()
    {
        Hero newHero = new Hero("Stefan", 10);
        repo.Create(this.hero);
        Assert.Throws<InvalidOperationException>(() => repo.Create(hero));
    }

    [Test]
    public void CreateHero_Correctyl()
    {
        repo.Create(this.hero);
        Assert.That(repo.Heroes.Count, Is.EqualTo(1));

        var result = repo.Create(new Hero("Gosho", 1));
        var expected = $"Successfully added hero Gosho with level 1";
        Assert.That(result == expected);
    }
    [Test]
    public void Remove_Throws_ExceptionNull()
    {
        Assert.Throws<ArgumentNullException>(() => repo.Remove(null));
        string whitespace = " ";
        Assert.Throws<ArgumentNullException>(() => repo.Remove(whitespace));
    }
    [Test]
    public void Remove_RemovesCorrectly()
    {
        repo.Create(hero);
        Assert.IsTrue(repo.Remove(hero.Name));
    }
    [Test]
    public void GetHeroWithHighestLevel_ReturnsCorrectly()
    {
        for (int i = 0; i < 5; i++)
        {
            repo.Create(new Hero("Stefan" + i, i));
        }

        Hero highest = repo.GetHeroWithHighestLevel();

        Assert.That(highest.Level == 4);
    }

    [Test]
    public void GetHero_ReturnsCorrectly()
    {
        repo.Create(hero);

        var newOldHero = repo.GetHero("Stefan");
        Assert.That(this.hero == newOldHero);
    }
}