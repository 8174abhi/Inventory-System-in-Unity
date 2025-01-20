using UnityEngine;
public enum ItemType
{
    Food,
    Equipment,
    Default
}
public class ItemObject : ScriptableObject
{
    public GameObject Prefab;
    public ItemType Itemtype;
    [TextArea(15,20)]
    public string Discription;


}
