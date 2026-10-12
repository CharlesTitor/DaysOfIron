using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryCanvas;

    private void Start()
    {
        _inventoryCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenCloseInventory();
        }
    }

    private void OpenCloseInventory()
    {
        _inventoryCanvas.SetActive(!_inventoryCanvas.activeSelf);
    }
}
