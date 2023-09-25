using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>, IEnumerable<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => models.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return models.FirstOrDefault(x => x.Username == property);
        }

        public IEnumerator<IRacer> GetEnumerator()
        {
            for (int i = 0; i < models.Count; i++)
            {
                yield return models[i];
            }
        }

        public bool Remove(IRacer model)
        {
            return models.Remove(model);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
