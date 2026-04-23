namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public readonly struct RecoverData
    {
        public RecoverData(Agent giver, int recoverValue)
        {
            this.giver = giver;
            this.recoverValue = recoverValue;
        }

        public static RecoverData Create(Agent giver, int recoverValue)
        {
            RecoverData result = new RecoverData(giver, recoverValue);
            return result;
        }

        public readonly Agent giver;
        public readonly int recoverValue;
    }
}
