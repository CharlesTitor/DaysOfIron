using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]

public class CursorObject : MonoBehaviour
{
    Color _startColor;
    [SerializeField] private Renderer _renderer;

    [SerializeField] private CursorManager.CursorType _cursorType;


    private void OnMouseEnter()
    {
        CursorManager.Instance.SetActiveCursorType(_cursorType);
        if (_cursorType == CursorManager.CursorType.Interactable)
        {
            _startColor = _renderer.material.color;
            _renderer.material.color = Color.red;
        }
    }


    private void OnMouseExit() { 
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Default);
        if (_cursorType == CursorManager.CursorType.Interactable)
        {
            _renderer.material.color = _startColor;
        }
    }
}
