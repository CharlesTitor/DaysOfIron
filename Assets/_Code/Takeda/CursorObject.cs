using UnityEngine;

[RequireComponent(typeof(Collider))]
//[RequireComponent (typeof(Rigidbody))]

public class CursorObject : MonoBehaviour
{
    //Color _startColor;
    private Material originalMaterial;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _outlineMaterial;

    [SerializeField] private CursorManager.CursorType _cursorType;


    private void OnMouseEnter()
    {
        CursorManager.Instance.SetActiveCursorType(_cursorType);
        if (_cursorType == CursorManager.CursorType.Interactable)
        {
            //_startColor = _renderer.material.color;
            //_renderer.material.color = Color.yellow;
            originalMaterial = _renderer.material;
            _renderer.material = _outlineMaterial;
        }
    }


    private void OnMouseExit() { 
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Default);
        if (_cursorType == CursorManager.CursorType.Interactable)
        {
            _renderer.material=originalMaterial;
        }
    }

    private void OnDestroy()
    {
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Default);
        if (_cursorType == CursorManager.CursorType.Interactable)
        {
            _renderer.material = originalMaterial;
        }
    }

}
