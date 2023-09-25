using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroGainsXPWhenTargetDies()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget
            .Setup(p => p.IsDead())
            .Returns(true);
        fakeTarget
            .Setup(p => p.GiveExperience())
            .Returns(10);
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Hero hero = new Hero("Alex", fakeWeapon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.That(hero.Experience, Is.EqualTo(10));
    }
}