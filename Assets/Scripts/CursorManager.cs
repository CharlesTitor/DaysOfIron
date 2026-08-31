using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public static CursorManager Instance { get; private set; }

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Texture2D interactTexture;
    [SerializeField] private Texture2D forbiddenTexture;

    private Vector2 cursorHotSpot;

    public enum CursorType
    {
        Default,
        Interactable,
        Forbidden
    }

    private void Awake()
    {
        Instance = this;
    }

    public void SetActiveCursorType(CursorType cursorType)
    {
        switch (cursorType)
        {
            case CursorType.Default:
                Cursor.SetCursor(cursorTexture, cursorHotSpot, CursorMode.Auto);
                break;
            case CursorType.Interactable:
                cursorHotSpot = new Vector2(interactTexture.width / 3,interactTexture.height / 3);
                Cursor.SetCursor(interactTexture, cursorHotSpot, CursorMode.Auto);
                break;
            case CursorType.Forbidden:
                Cursor.SetCursor(forbiddenTexture, cursorHotSpot, CursorMode.Auto);
                break;
        }
    }

    void Start()
    {
        Cursor.SetCursor(cursorTexture, cursorHotSpot, CursorMode.Auto);
    }
}
