namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            Employee employee = new Employee("11bh55");
            Robot robot = new Robot("12345Robot", 100);
            employee.Work(15);
            employee.Work(23);
            robot.Work(100);
            robot.Work(19);
            robot.Recharge();
            Console.WriteLine(robot.CurrentPower);
        }
    }
}
