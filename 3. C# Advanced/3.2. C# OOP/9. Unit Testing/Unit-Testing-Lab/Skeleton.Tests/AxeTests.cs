using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private ITarget target;

    [SetUp]
    public void Initialization()
    {
        target = new Dummy(10, 10);
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        axe = new Axe(10, 10);

        axe.Attack(target);

        Assert.That(axe.DurabilityPoints, 
            Is.EqualTo(9), 
            "Axe's Durability doesn't change after attack.");
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        axe = new Axe(1, 0);

        Assert.That(() => axe.Attack(target),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Axe is broken."),
            "Axe attacks when broken.");
    }
}