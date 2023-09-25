namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    [TestFixture]
    public class RobotsTests
    {
        RobotManager robotManager;
        Robot robot;

        [SetUp]
        public void Initialization()
        {
            robotManager = new RobotManager(10);
            robot = new Robot("Gosho", 100);
        }

        //3 tests passed
        [Test]
        public void Ctor_InitializesProperties()
        {
            List<Robot> robotsFieldValue = (List<Robot>)typeof(RobotManager)
                   .GetField("robots", BindingFlags.NonPublic | BindingFlags.Instance)
                   .GetValue(robotManager);

            Assert.That(robotsFieldValue.Count == 0);
            Assert.That(robotManager.Count == 0);
            Assert.That(robotManager.Capacity == 10);
            Assert.That(robot.Name == "Gosho");
            Assert.That(robot.Battery == 100);
            Assert.That(robot.MaximumBattery == 100);
        }

        //1 tests passed
        [Test]
        public void Capacity_ThrowsExceptionWhenValueBelowZero()
        {
            Assert.That(() => new RobotManager(-1),
                Throws.ArgumentException
                .With.Message.EqualTo("Invalid capacity!"));
        }

        //0 tests passed
        [Test]
        public void Add_AddsValidRobot()
        {
            robotManager.Add(robot);
            List<Robot> robotsFieldValue = (List<Robot>)typeof(RobotManager)
                .GetField("robots", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(robotManager);

            Assert.That(robotsFieldValue.Contains(robot));
            Assert.That(robotManager.Count == 1);
        }

        //1 tests passed
        [Test]
        public void Add_ThrowsExceptionWhenRobotAlreadyExists()
        {
            robotManager.Add(robot);

            Assert.That(() => robotManager.Add(robot),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"There is already a robot with name {robot.Name}!"));
        }

        //0 tests passed
        [Test]
        public void Add_ThrowsExceptionWhenCapacityExceeded()
        {
            for (int i = 0; i < 10; i++)
            {
                robotManager.Add(new Robot($"{i}", i));
            }

            Assert.That(() => robotManager.Add(robot),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Not enough capacity!"));
        }

        //0 tests passed
        [Test]
        public void Remove_RemovesValidRobot()
        {
            robotManager.Add(robot);
            robotManager.Remove(robot.Name);
            List<Robot> robotsFieldValue = (List<Robot>)typeof(RobotManager)
                .GetField("robots", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(robotManager);

            Assert.That(robotsFieldValue.Contains(robot) == false);
            Assert.That(robotManager.Count == 0);
        }

        //1 tests passed
        [Test]
        public void Remove_ThrowsExceptionWhenRobotDoesntExist()
        {
            Assert.That(() => robotManager.Remove(robot.Name),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"Robot with the name {robot.Name} doesn't exist!"));
        }

        //0 tests passed
        [Test]
        public void Work_DecreasesRobotBattery()
        {
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "dancing", 60);

            Assert.That(robot.Battery == 40);
        }

        //1 tests passed
        [Test]
        public void Work_ThrowsExceptionWhenRobotDoesntExist()
        {
            Assert.That(() => robotManager.Work(robot.Name, "dancing", 50),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"Robot with the name {robot.Name} doesn't exist!"));
        }

        //1 tests passed
        [Test]
        public void Work_ThrowsExceptionWhenRobotDoesntHaveEnoughBattery()
        {
            robotManager.Add(robot);

            Assert.That(() => robotManager.Work(robot.Name, "dancing", 150),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"{robot.Name} doesn't have enough battery!"));
        }

        //1 tests passed
        [Test]
        public void Charge_IncreasesRobotBatteryToMaximum()
        {
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "dancing", 50);
            robotManager.Charge(robot.Name);

            Assert.That(robot.Battery == robot.MaximumBattery);
        }

        //0 tests passed
        [Test]
        public void Charge_ThrowsExceptionWhenRobotDoesntExist()
        {
            Assert.That(() => robotManager.Charge(robot.Name),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"Robot with the name {robot.Name} doesn't exist!"));
        }
    }
}
