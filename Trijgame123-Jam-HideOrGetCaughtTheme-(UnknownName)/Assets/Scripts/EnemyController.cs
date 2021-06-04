using UnityEngine;
using Unity.Collections;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent _agentMovement;
    NavMeshPath _navMeshPath;

    public bool _canSeePlayer;
    bool _pathFindBool;

    public Transform[] wayPoints;
    int destinationPoints;

    private void Start()
    {
        _agentMovement = GetComponent<NavMeshAgent>();
        _navMeshPath = new NavMeshPath();
        destinationPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit _rayCastHit;
        Ray _ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(_ray, out _rayCastHit, 4f))
        {
            if (_rayCastHit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("hit player");
                _agentMovement.destination = _rayCastHit.collider.gameObject.transform.position;
                _canSeePlayer = true;
            }
        }
        else
        {
            _canSeePlayer = false;
        }

        if (_canSeePlayer == false)
        {
            if (!_agentMovement.pathPending/* && _agentMovement.remainingDistance < 0.5f*/)
                PathDestination();
            Debug.Log("cant see");
        }
    }

    // 
    void PathDestination()
    {
        if (wayPoints.Length == 0)
            return;

        _agentMovement.destination = wayPoints[destinationPoints].position;
        destinationPoints = (destinationPoints + 1) % wayPoints.Length;
    }
}