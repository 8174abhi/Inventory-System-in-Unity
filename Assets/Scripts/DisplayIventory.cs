using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayIventory : MonoBehaviour
{
    public int X_Space_Between_Item;
    public int Y_Space_Between_Item;
    public int X_Start;
    public int Y_Start;
    public int Number_of_Column;
    Dictionary<InventorySlot,GameObject>ItemDisplayed= new Dictionary<InventorySlot,GameObject>();
    public InventoryObject Inventory;

    private void Start()
    {
      CreateDisplay();
    }
    private void Update()
    {
        UpdateDisplay();

    }
    public void UpdateDisplay()
    {
        for (int i = 0; i < Inventory.Container.Count; i++)
        {
            if (ItemDisplayed.ContainsKey(Inventory.Container[i]))
            {
                ItemDisplayed[Inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = Inventory.Container[i].Amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(Inventory.Container[i].item.Prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = Inventory.Container[i].Amount.ToString("n0");
                ItemDisplayed.Add(Inventory.Container[i], obj);
            }
        }
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < Inventory.Container.Count; i++)
        {
            var obj = Instantiate(Inventory.Container[i].item.Prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = Inventory.Container[i].Amount.ToString("n0");
            ItemDisplayed.Add(Inventory.Container[i], obj);
        }
    }

    public Vector3  GetPosition(int i)
    {
        return new Vector3(X_Start+ X_Space_Between_Item * (i % Number_of_Column),Y_Start+ (-Y_Space_Between_Item * (i / Number_of_Column)), 0f);
    }
}
