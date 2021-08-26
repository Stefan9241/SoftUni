using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private int attackPoints = 10;
    private int durabilityPoints = 10;
    private Axe axe;
    private Dummy dummy;
    [SetUp]
    public void SetUp()
    {
        this.axe = new Axe(attackPoints,durabilityPoints);
        this.dummy = new Dummy(10,10);
    }
    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        this.axe.Attack(this.dummy);
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9),"Durability doesn't change");
    }

    [Test]
    public void AxeAttackingWithBrockenWeapon()
    {
        Axe brokenAxe = new Axe(10, -1);

        Assert.That(() =>
        {
            brokenAxe.Attack(dummy);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}