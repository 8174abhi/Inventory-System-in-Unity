using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Food")]

public class FoodObject : ItemObject
{
    public int RestoreHealthValue;

    private void Awake()
    {
        Itemtype = ItemType.Food;
    }
}
