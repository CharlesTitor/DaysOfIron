// Tutorial video: https://www.youtube.com/watch?v=LdoImzaY6M4

using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private GameObject _screen;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            float interactRange = 1f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    npcInteractable.Interact();
                    Time.timeScale = 0;
                    _screen.SetActive(true);
                }
            }
        }
    }
}