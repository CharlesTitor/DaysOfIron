using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> inventory = new List<Item>();

    [Header("Debug")]
    public ItemData testItemData;
    public ItemData testItemData2;
    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AddItem(testItemData, 5);
        AddItem(testItemData2, 1);
        AddItem(testItemData, 10);

        GetComponent<InventoryManagerUI>().RefreshInventoryUI();
    }

    public void AddItem(ItemData a, int b)
    {
        foreach (Item item in inventory)
        {
            if(item.ItemData.itemName == a.itemName)
            {
                item.itemQuantity += b;
                return;
            }
        }

        inventory.Add(new Item { ItemData = a, itemQuantity = b });
    }
}
