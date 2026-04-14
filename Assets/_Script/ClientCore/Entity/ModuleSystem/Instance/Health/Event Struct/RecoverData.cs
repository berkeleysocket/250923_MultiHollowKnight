namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public readonly struct RecoverData
    {
        public RecoverData(Entity giver, int recoverValue)
        {
            this.giver = giver;
            this.recoverValue = recoverValue;
        }

        public static RecoverData Create(Entity giver, int recoverValue)
        {
            RecoverData result = new RecoverData(giver, recoverValue);
            return result;
        }

        public readonly Entity giver;
        public readonly int recoverValue;
    }
}
