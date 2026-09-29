using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> inventory = new List<Item>();

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

        GetComponent<HotbarManager>().RefreshHotbar();
        GetComponent<InventoryManagerUI>().RefreshInventoryUI();
    }

    public void AddItem(ItemData typeOfItem, int cuantityOfItem)
    {
        foreach (Item item in inventory)
        {
            if(item.ItemData.ItemName == typeOfItem.ItemName)
            {
                item.itemQuantity += cuantityOfItem;
                return;
            }
        }

        inventory.Add(new Item { ItemData = typeOfItem, itemQuantity = cuantityOfItem });
    }
}
