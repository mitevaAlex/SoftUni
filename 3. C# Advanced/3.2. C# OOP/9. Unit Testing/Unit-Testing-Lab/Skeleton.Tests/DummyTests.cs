using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;

    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        dummy = new Dummy(10, 10);

        dummy.TakeAttack(1);

        Assert.That(dummy.Health, Is.EqualTo(9));
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        dummy = new Dummy(-10, 10);

        Assert.That(() => dummy.TakeAttack(10),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyGivesXP()
    {
        dummy = new Dummy(-10, 1);

        Assert.That(() => dummy.GiveExperience(), Is.EqualTo(1));
    }

    [Test]
    public void AliveDummyDoesntGiveXP()
    {
        dummy = new Dummy(100, 1);

        Assert.That(() => dummy.GiveExperience(),
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }

}
