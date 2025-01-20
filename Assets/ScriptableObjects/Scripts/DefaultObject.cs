using System;
using UnityEngine;

[CreateAssetMenu(fileName ="New Default Object",menuName ="Inventory System/Default")]
public class DefaultObject : ItemObject
{
    private void Awake()
    {
       Itemtype=ItemType.Default;
    }
}
