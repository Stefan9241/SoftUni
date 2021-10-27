namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        [SetUp]
        public void SetUp()
        {
            robotManager = new RobotManager(5);
            robot = new Robot("Stefan", 5);
        }
        [Test]
        public void CreateRobot_CapacityCorrectly()
        {
            Assert.That(robotManager.Capacity == 5);
        }
        [Test]
        public void CreateRobot_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-10));
        }
        [Test]
        public void RobotCountCorrectly()
        {
            robotManager.Add(robot);
            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        public void CountCorrectly()
        {
            Assert.That(robotManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void RobotAddThrows_Exception_AlreadyAdded()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        public void RobotAddThrows_Exception_Capacity()
        {
            var manager = new RobotManager(1);
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot("gosho",100)));
        }

        [Test]
        public void RobotRemoveThrows_Exception_Null()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(null));
        }

        [Test]
        public void RobotRemoveCorrectly()
        {
            robotManager.Add(robot);
            robotManager.Remove(robot.Name);
            Assert.That(robotManager.Count == 0);
        }

        [Test]
        public void RobotWork_Exception_Null()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(null,"loshko",5));
        }
        [Test]
        public void RobotRemoveThrows_Exception_Battery()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robot.Name,"Sing",10));
        }

        [Test]
        public void Robot_Battery()
        {
            robotManager.Add(robot);
            robotManager.Charge(robot.Name);
            robotManager.Work(robot.Name, "walk", 1);
            Assert.That(robot.Battery == 4);
        }

        [Test]
        public void Robot_charge_Correctly()
        {
            robotManager.Add(robot);
            robotManager.Charge(robot.Name);
            Assert.That(robot.Battery == robot.MaximumBattery);
        }

        [Test]
        public void RobotChargeThrows_Exception_Null()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(null));
        }
        [Test]
        public void WorkMethod_Should_DecreaseBatteryCorrectly()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Sofia", 100);

            robotManager.Add(robot);
            robotManager.Work("Sofia", "Manager", 50);

            Assert.That(robot.Battery, Is.EqualTo(50));
        }

        [Test]
        public void ChargeMethod_ShouldChargeRobotCorrectly()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Sofia", 100);

            robotManager.Add(robot);
            robotManager.Work("Sofia", "Manager", 80);
            robotManager.Charge("Sofia");

            Assert.That(robot.Battery, Is.EqualTo(100));
        }
    }
}
