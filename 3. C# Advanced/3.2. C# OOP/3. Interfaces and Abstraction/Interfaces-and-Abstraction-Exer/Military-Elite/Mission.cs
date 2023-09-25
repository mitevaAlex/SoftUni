using System;

namespace Military_Elite
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            if (state != "inProgress" && state != "Finished")
            {
                throw new ArgumentException("Invalid mission state");
            }

            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public string State { get; private set; }//inProgress || Finished

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}";
        }
    }
}