using UnityEngine;
using UnityEngine.AI;

public class EnemyCon_02 : MonoBehaviour
{
    public bool _canSeePlayer;
    bool _canMovePatrol;

    public Transform[] wayPoints;

    NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit _rayCastHit;
        Ray _ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(_ray, out _rayCastHit, 4f))
        {
            if (_rayCastHit.collider.gameObject.CompareTag("Player"))
            {
                _navMeshAgent.destination = _rayCastHit.collider.gameObject.transform.position;
                _canSeePlayer = true;
                Time.timeScale = 0.1f;
            }
        }
        else
        {
            _canSeePlayer = false;
        }

        if (_canSeePlayer == false)
        {
            if (_canMovePatrol == false)
            {
                _navMeshAgent.SetDestination(wayPoints[0].position);
            }
            if (Vector3.Distance(transform.position, wayPoints[0].position) <= 1f)
            {
                _canMovePatrol = true;
            }
            if (_canMovePatrol == true)
            {
                _navMeshAgent.SetDestination(wayPoints[1].position);
            }
            if (Vector3.Distance(transform.position, wayPoints[1].position) <= 1f)
            {
                _canMovePatrol = false;
            }
        }
    }
}