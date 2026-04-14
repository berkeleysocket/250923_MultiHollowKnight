namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public readonly struct RecoverResultData
    {
        public RecoverResultData(global::Agent giver, int recoverValue)
        {
            this.giver = giver;
            this.recoverValue = recoverValue;
        }

        public static RecoverResultData Create(global::Agent giver, int recoverValue)
        {
            RecoverResultData result = new RecoverResultData(giver, recoverValue);
            return result;
        }

        public readonly global::Agent giver;
        public readonly int recoverValue;
    }
}

