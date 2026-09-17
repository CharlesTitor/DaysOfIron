using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public ItemData ItemData;

    private bool _mouseOver=false;

    private void OnMouseEnter()
    {
        _mouseOver=true;
    }

    private void OnMouseExit()
    {
        _mouseOver=false;
    }

    private void Update()
    {
        if (_mouseOver == true && Input.GetKeyDown(KeyCode.C))
        {
            PickUpItem();
        }
    }

    private void PickUpItem()
    {
        InventoryManager.Instance.AddItem(ItemData, 1);

        InventoryManagerUI inventoryUI= FindObjectOfType<InventoryManagerUI>();

        if (inventoryUI != null)
        {
            inventoryUI.RefreshInventoryUI();
        }

        Destroy(gameObject);
    }
}
