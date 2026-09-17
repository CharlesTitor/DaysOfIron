using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/New Item")]


public class ItemData : ScriptableObject
{
    public enum ItemType //declarar una lista de opciones
    {
        Materials,
        Tools,
        Components, //No se como ponerle a lo de la bombs pero va aquí
        Armor
    }
    public string itemName;
    public Sprite itemIcon;
    public string itemDescripcion;
    public ItemType itemType;
}
