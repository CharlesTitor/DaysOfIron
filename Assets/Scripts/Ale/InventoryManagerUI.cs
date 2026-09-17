using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerUI : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    public Transform inventoryContainer;

    private void Start()
    {
        RefreshInventoryUI();
    }

    public void RefreshInventoryUI()
    {
        //0. Clear existing UI elements
        foreach(Transform slot in inventoryContainer)
        {
            Destroy(slot.gameObject);
        }

        //1. Create UI elements for each item in the inventory
        foreach(Item item in InventoryManager.Instance.inventory)
        {
            GameObject newItemSlot = Instantiate(itemSlotPrefab, inventoryContainer);

            ItemSlotUI itemSlotUI = newItemSlot.GetComponent<ItemSlotUI>();

            itemSlotUI.itemIconImage.sprite = item.ItemData.itemIcon;
            itemSlotUI.itemNameText.text = item.ItemData.itemName;
            itemSlotUI.itemQuantityText.text = "x" + item.itemQuantity.ToString();
        }
    }
}
