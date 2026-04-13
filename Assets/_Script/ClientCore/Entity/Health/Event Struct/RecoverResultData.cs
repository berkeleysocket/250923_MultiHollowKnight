namespace Ksy.Agent.Module.HealthSystem
{
    public readonly struct RecoverResultData
    {
        public RecoverResultData(Entity giver, int recoverValue)
        {
            this.giver = giver;
            this.recoverValue = recoverValue;
        }

        public static RecoverResultData Create(Entity giver, int recoverValue)
        {
            RecoverResultData result = new RecoverResultData(giver, recoverValue);
            return result;
        }

        public readonly Entity giver;
        public readonly int recoverValue;
    }
}

