using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/New Item")]


public class ItemData : ScriptableObject
{
    public enum ItemType //declarar una lista de opciones
    {
        Consumable,
        Equipment,
    }
    public string itemName;
    public Sprite itemIcon;
    public string itemDescripcion;
    public ItemType itemType;
}
