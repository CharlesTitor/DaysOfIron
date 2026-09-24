using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    private NavMeshAgent agent;
   

    [Header("Movement Settings")]
    public float moveSpeed = 10f;

    [Header("Movement Settings")]
    [SerializeField] float sampleDistance = 0.5f;
    [SerializeField] LayerMask groundLayer;

    public static event System.Action<Vector3> OnGroundTouch;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        

        agent.speed = moveSpeed;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                if (NavMesh.SamplePosition(hit.point, out NavMeshHit navMeshHit, sampleDistance, NavMesh.AllAreas))
                {
                    agent.SetDestination(navMeshHit.position);
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