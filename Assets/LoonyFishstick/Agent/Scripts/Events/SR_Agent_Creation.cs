
namespace LF.Agent
{
    public readonly struct SR_Agent_Creation
    {
        public SR_Agent_Creation(
            string agentName)
        {
            this.agentName = agentName;
        }

        public readonly string agentName;
    }
}
