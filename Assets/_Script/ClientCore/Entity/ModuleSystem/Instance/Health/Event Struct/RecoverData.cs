namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public readonly struct RecoverData
    {
        public RecoverData(Agent giver, int resourceValue, int recoverValue)
        {
            this.giver = giver;
            this.resourceValue = resourceValue;
            this.recoverValue = recoverValue;
        }

        public static RecoverData Create(Agent giver, int resourceValue, int recoverValue)
        {
            RecoverData result = new RecoverData(giver, resourceValue, recoverValue);
            return result;
        }

        public readonly Agent giver;
        public readonly int resourceValue;
        public readonly int recoverValue;
    }
}
