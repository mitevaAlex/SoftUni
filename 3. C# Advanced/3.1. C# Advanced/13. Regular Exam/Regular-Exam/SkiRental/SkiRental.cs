using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Ski>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Ski ski)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (data.Exists(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                data.Remove(data.Find(x => x.Manufacturer == manufacturer && x.Model == model));
                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            if (data.Count == 0)
            {
                return null;
            }

            return data.Find(x => x.Year == data.Max(x => x.Year));
        }

        public Ski GetSki(string manufacturer, string model)
        {
            if (data.Exists(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                return data.Find(x => x.Manufacturer == manufacturer && x.Model == model);
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (Ski ski in this.data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
