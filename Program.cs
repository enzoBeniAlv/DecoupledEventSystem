
using System;

public class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Event System Simulation");
        var questTracker = new QuestTracker();
        var achievementTracker = new AchievementTracker();
        var itemTracker = new ItemCollectionTracker();

        // Simulate events
        EventBus.Publish(new EnemyKilledEvent("Goblin", 50));
        EventBus.Publish(new ItemCollectedEvent("Gold teeth", 10));
        EventBus.Publish(new EnemyKilledEvent("Orc", 100));
        EventBus.Publish(new ItemCollectedEvent("Orc eyes", 2));
        EventBus.Publish(new ItemCollectedEvent("Health Potion", 3));
        EventBus.Publish(new EnemyKilledEvent("Dragon", 500));
        EventBus.Publish(new ItemCollectedEvent("DragonHeart", 1));

        // Unsubscribe trackers
        questTracker.Unsubscribe();
        achievementTracker.Unsubscribe();
        itemTracker.Unsubscribe();

    }
}
