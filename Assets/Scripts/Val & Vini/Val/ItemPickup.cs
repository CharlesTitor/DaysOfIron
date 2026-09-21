using UnityEngine;

public class ItemPickup : MonoBehaviour, IPickable
{
    public ItemData ItemData;
    [SerializeField] private float _pickupDistance = 5f;
    [SerializeField] private int _quantity = 1;


    private void OnMouseDown()
    {
        //TODO : Change Camera.main.transform.position to player position
        if (Vector3.Distance(this.transform.position, Camera.main.transform.position) <= _pickupDistance)
        {
            PickUp();
        }
    }

    public void PickUp()
    {
        InventoryManager.Instance.AddItem(ItemData, _quantity);

        InventoryManagerUI.Instance.RefreshInventoryUI();

        Destroy(gameObject);
    }
}
