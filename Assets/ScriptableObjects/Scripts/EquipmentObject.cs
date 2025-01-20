using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Equipment")]

public class EquipmentObject :ItemObject
{
    public float AttackBonus;
    public float DifenceBonus;
    public void Awake()
    {
        Itemtype= ItemType.Equipment;
    }
}
