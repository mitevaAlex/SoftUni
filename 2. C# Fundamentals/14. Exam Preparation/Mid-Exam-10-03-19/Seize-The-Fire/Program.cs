using System;
using System.Collections.Generic;
using System.Linq;

namespace Seize_The_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            //"{typeOfFire} = {valueOfCell}#{typeOfFire} = {valueOfCell}#{typeOfFire} = {valueOfCell}……"
            string[] fireCellsData = Console.ReadLine()
                .Split('#', StringSplitOptions.RemoveEmptyEntries);
            int water = int.Parse(Console.ReadLine());

            List<FireCell> fireCells = new List<FireCell>();
            foreach (string cell in fireCellsData)
            {
                string[] cellData = cell
                    .Split(" = ", StringSplitOptions.RemoveEmptyEntries);
                FireCell fireCell = new FireCell(cellData[0], int.Parse(cellData[1]));
                fireCells.Add(fireCell);
            }
            List<FireCell> puttedOutCells = new List<FireCell>();
            double effort = 0.0;
            for (int i = 0; i < fireCells.Count; i++)
            {
                FireCell currentCell = fireCells[i];
                if (currentCell.IsValueValid() && water - currentCell.Value >= 0)
                {
                    water -= currentCell.Value;
                    effort += currentCell.Value * 0.25;
                    puttedOutCells.Add(currentCell);
                }
            }

            Console.WriteLine("Cells:");
            puttedOutCells.ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"Effort: {effort:F2}");
            Console.WriteLine($"Total Fire: {puttedOutCells.Sum(x => x.Value)}");
        }
    }
}
