
public readonly struct EnemyKilledEvent : IGameEvent
{
    public string EnemyName { get; }
    public int ExpRewarded { get; }

    public EnemyKilledEvent(string enemyName, int expRewarded)
    {
        EnemyName = enemyName;
        ExpRewarded = expRewarded;
    }
}