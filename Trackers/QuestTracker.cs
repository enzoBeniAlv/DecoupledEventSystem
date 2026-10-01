
public class QuestTracker
{
    private int KillCount { get; set;}

    public QuestTracker()
    {
        KillCount = 0;
        EventBus.Subscribe<EnemyKilledEvent>(OnEnemyKilled);
    }

    private void OnEnemyKilled(EnemyKilledEvent eventData)
    {
        KillCount++;
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine($"QuestTracker: Enemy killed: {eventData.EnemyName} Exp: {eventData.ExpRewarded}. Total kills: {KillCount}");
    }

    public void Unsubscribe()
    {
        EventBus.Unsubscribe<EnemyKilledEvent>(OnEnemyKilled);
        Console.WriteLine("QuestTracker: Unsubscribed from EnemyKilledEvent.");
    }
}