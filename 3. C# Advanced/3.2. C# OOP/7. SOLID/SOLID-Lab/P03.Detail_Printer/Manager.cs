using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : IWorker
    {
        private List<string> documents;

        public Manager(string name, ICollection<string> documents)
        {
            Name = name;
            this.documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents => this.documents.AsReadOnly();

        public string Name { get; }

        public string Info => $"{this.Name}{Environment.NewLine}{string.Join(Environment.NewLine, this.Documents)}";
    }
}
