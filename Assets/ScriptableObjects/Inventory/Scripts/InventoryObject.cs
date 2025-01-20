using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject,ISerializationCallbackReceiver
{
    public List<InventorySlot> Container=new List<InventorySlot>();
    public ItemDataBaseObject Database;
    public string SavePath;
    public void OnEnable()
    {
#if UNITY_EDITOR
        Database=(ItemDataBaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDataBaseObject));
#else
        Database = Resources.Load<ItemDataBaseObject>("Database");
#endif
    }
    public void AddItem(ItemObject _item,int _amount)
    {
        //bool HasItem=false;
        for(int i = 0; i <Container.Count; i++) 
        {
            if (Container[i].item == _item)
            
            {
                Container[i].AddAmount(_amount);
                return;
              
                
            }
        }
       
        
            Container.Add(new InventorySlot(Database.GetID[_item], _item,_amount));
        
    }
    public void OnAfterDeserialize()
    {
       for (int i = 0;i < Container.Count;i++)
        {
            Container[i].item = Database.GetItem[Container[i].ID];
        }
    }
    public void OnBeforeSerialize()
    {

    }
    public void Save()
    {
        string SaveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf=new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, SavePath));
        bf.Serialize(file, SaveData);
        file.Close();
            
    }
    public void Load()
    {
        if(!File.Exists(string.Concat(Application.persistentDataPath,SavePath)))
        {
            BinaryFormatter bf=new BinaryFormatter();
            FileStream file=File.Open(string.Concat(Application.persistentDataPath,SavePath),FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(),this);
            file.Close();
        }
    }
}
[System.Serializable]
public class InventorySlot
{
    public int ID;
    public ItemObject item;
    public int Amount;
    public InventorySlot(int id,ItemObject _item, int _amount)
    {
        item = _item;
        Amount = _amount;
    }
    public void AddAmount(int value)
    {
        Amount += value;
    }
}
