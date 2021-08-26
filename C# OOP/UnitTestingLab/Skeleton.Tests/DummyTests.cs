using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private int hp = 10;
    private int exp = 10;
    private Axe axe;
    private Dummy dummy;
    private Dummy deadDummy;
    [SetUp]
    public void SetUp()
    {
        this.dummy = new Dummy(hp,exp);
        this.axe = new Axe(hp, exp);
        this.deadDummy = new Dummy(-1, exp);
    }

    [Test]
    public void DummyLoosesHealth_IfAttacked()
    {
        dummy.TakeAttack(1);
        Assert.That(dummy.Health,Is.EqualTo( 9));
    }

    [Test]
    public void CheckIfDeadDummyThrowsException_IfAttacked()
    {
        Assert.That(() =>
        {
            this.axe.Attack(deadDummy);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void When_AliveDummy_ShouldThrow()
    {
        Assert.That(() =>
        {
            dummy.GiveExperience();
        }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }

    [Test]
    public void When_DeadDummy_ShouldGiveXp()
    {
        Assert.That(deadDummy.GiveExperience(), Is.EqualTo(exp));
    }

    [Test]
    public void When_HpIsPositive_ShouldBeAlive()
    {
        Assert.That(dummy.IsDead, Is.EqualTo(false));
    }

    [Test]
    public void When_HpIsNegative_ShouldBeDead()
    {
        Assert.That(deadDummy.IsDead, Is.EqualTo(true));
    }

}
