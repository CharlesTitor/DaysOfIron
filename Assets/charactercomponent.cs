using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Character : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    [Header("Movement Settings")]
    [FormerlySerializedAs("moveSpeed")]
    public float MoveSpeed = 10f;

    [FormerlySerializedAs("sampleDistance")]
    [SerializeField] float _sampleDistance = 0.5f;
    [FormerlySerializedAs("groundLayer")]
    [SerializeField] LayerMask _groundLayer;

    public static event System.Action<Vector3> OnGroundTouch;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = MoveSpeed;
    }

    void Update()
    {
        GroundClickVerification();
    }

    private void GroundClickVerification()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _groundLayer))
            {
                if (NavMesh.SamplePosition(hit.point, out NavMeshHit navMeshHit, _sampleDistance, NavMesh.AllAreas))
                {
                    _navMeshAgent.SetDestination(navMeshHit.position);
                    OnGroundTouch?.Invoke(navMeshHit.position);
                }
                else
                {
                    Debug.Log("No valid NavMesh position found.");
                }
            }
        }
    }
}