using UnityEngine;

public class CursorObject : MonoBehaviour
{

    [SerializeField] private CursorManager.CursorType _cursorType;


    private void OnMouseEnter()
    {
        CursorManager.Instance.SetActiveCursorType(_cursorType);
    }


    private void OnMouseExit() { 
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Default);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
