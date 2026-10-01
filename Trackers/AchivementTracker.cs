public class AchievementTracker
{
    private int KillCount { get; set;}
    private int AchievementThreshold = 3;
    private bool achievementUnlocked = false;

    private int ExpRewarded = 0;

    public AchievementTracker()
    {
        EventBus.Subscribe<EnemyKilledEvent>(OnEnemyKilled);
    }

    private void OnEnemyKilled(EnemyKilledEvent eventData)
    {
        KillCount++;
        ExpRewarded += eventData.ExpRewarded;
        if (KillCount >= AchievementThreshold && !achievementUnlocked)
        {
            achievementUnlocked = true;
            Console.WriteLine($"AchievementTracker: Achievement unlocked! AchievementExp: {ExpRewarded} Total kills: {KillCount}");
        }
    }

    public void Unsubscribe()
    {
        EventBus.Unsubscribe<EnemyKilledEvent>(OnEnemyKilled);
        Console.WriteLine("AchievementTracker: Unsubscribed from EnemyKilledEvent.");
    }
}