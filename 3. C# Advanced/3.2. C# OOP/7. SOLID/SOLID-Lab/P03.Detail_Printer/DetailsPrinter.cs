using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IWorker> workers;

        public DetailsPrinter(IList<IWorker> workers)
        {
            this.workers = workers;
        }

        public string PrintDetails()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IWorker worker in this.workers)
            {
                sb.AppendLine(worker.Info);
            }

            return sb.ToString().Trim();
        }
    }
}
