using MilitaryElite.Interfaces;
using System;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string state;
        public string CodeName { get; private set; }
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        public string State
        {
            get
            {
                return this.state;
            }

            private set
            {
                //MissionState state;!Enum.TryParse<MissionState>(value, out state)

                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException();
                }

                this.state = value;
            }
        }
        public void CompleteMission()
        {
            this.state = "Finished";
        }
        public override string ToString()
        {
            return $"  Code Name: {CodeName} State: {State}";
        }
    }
}
