using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    public static HotbarManager Instance;

    [SerializeField] private Transform _hotbarContainer;
    private  GameObject _itemSlotPrefab;

    private int _slotQuantity = 3;

    public Transform HotbarContainer {  get { return _hotbarContainer; } }


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

        int numberOfSlots = Mathf.Min(_slotQuantity, InventoryManager.Instance.Inventory.Count);

        
        for (int i=0; i<numberOfSlots; i++)
        {
            Item item= InventoryManager.Instance.Inventory[i];

            GameObject newItemSlot= Instantiate(_itemSlotPrefab, HotbarContainer);

            ItemSlotUI itemSlotUI= newItemSlot.GetComponent<ItemSlotUI>();

            itemSlotUI.ItemIconImage.sprite = item.ItemData.ItemIcon;
            itemSlotUI.ItemNameText.text = item.ItemData.ItemName;
            itemSlotUI.ItemQuantityText.text = "x" + item.ItemQuantity.ToString();
        }
    }

}
