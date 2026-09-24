using UnityEngine;
using UnityEngine.InputSystem;

public class HotbarManager : MonoBehaviour
{
    public static HotbarManager Instance;
    public Transform HotbarContainer;
    public GameObject ItemSlotPrefab;

    private int _slotQuantity=3;

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

    private void Update()
    {
        RefreshHotbar();
    }

    public void RefreshHotbar()
    {
        foreach (Transform slot in HotbarContainer)
        {
            Destroy(slot.gameObject);
        }

        int numberOfSlots = Mathf.Min(_slotQuantity, InventoryManager.Instance.inventory.Count);

        
        for (int i=0; i<numberOfSlots; i++)
        {
            Item item= InventoryManager.Instance.inventory[i];

            GameObject newItemSlot= Instantiate(ItemSlotPrefab, HotbarContainer);

            ItemSlotUI itemSlotUI= newItemSlot.GetComponent<ItemSlotUI>();

            itemSlotUI.itemIconImage.sprite = item.ItemData.ItemIcon;
            itemSlotUI.itemNameText.text = item.ItemData.ItemName;
            itemSlotUI.itemQuantityText.text = "x" + item.itemQuantity.ToString();
        }
    }

}
