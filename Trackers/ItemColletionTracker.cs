
public class ItemCollectionTracker
{
    private int ItemCount { get; set; }

    public ItemCollectionTracker()
    {
        ItemCount = 0;
        EventBus.Subscribe<ItemCollectedEvent>(OnItemCollected);
    }

    private void OnItemCollected(ItemCollectedEvent eventData)
    {
        ItemCount += eventData.Quantity;
        Console.WriteLine($"ItemCollectionTracker: Item collected: {eventData.ItemName} Quantity: {eventData.Quantity}. Total items: {ItemCount}");
    }

    public void Unsubscribe()
    {
        EventBus.Unsubscribe<ItemCollectedEvent>(OnItemCollected);
        Console.WriteLine("ItemCollectionTracker: Unsubscribed from ItemCollectedEvent.");
    }
}