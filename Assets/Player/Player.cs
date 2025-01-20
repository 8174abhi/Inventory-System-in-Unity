using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public float MSpeed = 10f;
    private void Update()
    {
        MoveMent();
        if (Input.GetKey(KeyCode.Space))
        {
            inventory.Save();
            Debug.Log("Saved");
        }
        if(Input.GetKey(KeyCode.M))
        {
            inventory.Load();
            Debug.Log("Load");
        }
    }
    void MoveMent()
    {
        float X = Input.GetAxis("Horizontal")*MSpeed*Time.deltaTime;
        float Y = Input.GetAxis("Vertical")*MSpeed*(Time.deltaTime);  
        transform.position += new Vector3(X, 0, Y);
    }
    public void OnTriggerEnter(Collider other)
    {
        var item =other.GetComponent<Item>();
        if(item)
        {
            inventory.AddItem(item.item,1);
            Destroy(other.gameObject);
        }
    }
    public void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
