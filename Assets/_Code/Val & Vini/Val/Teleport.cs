using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _teleportPoint;

    private void OnTriggerEnter(Collider kael)
    {
        if (kael.CompareTag("Player"))
        {
            kael.transform.position = _teleportPoint.position;
        }
    }
}
