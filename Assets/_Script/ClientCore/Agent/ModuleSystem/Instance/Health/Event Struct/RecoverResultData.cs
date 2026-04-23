namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public readonly struct RecoverResultData
    {
        public RecoverResultData(Agent giver, int resourceValue, int recoverValue)
        {
            this.giver = giver;
            this.resourceValue = resourceValue;
            this.recoverValue = recoverValue;
        }

        public static RecoverResultData Create(Agent giver, int resourceValue, int recoverValue)
        {
            RecoverResultData result = new RecoverResultData(giver, resourceValue, recoverValue);
            return result;
        }

        public readonly Agent giver;
        public readonly int resourceValue;
        public readonly int recoverValue;
    }
}

