
public readonly struct ItemCollectedEvent : IGameEvent
{
    public string ItemName { get; }
    public int Quantity { get; }

    public ItemCollectedEvent(string itemName, int quantity)
    {
        ItemName = itemName;
        Quantity = quantity;
    }
}