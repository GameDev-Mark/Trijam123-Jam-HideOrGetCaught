using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agentMovement;

    private void Start()
    {
        agentMovement = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit _rayCastHit;
        Ray _ray = new Ray(transform.position, Vector3.forward);

        if(Physics.Raycast(_ray, out _rayCastHit, 4f))
        {
            if (_rayCastHit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("hit player");
                agentMovement.nextPosition = _rayCastHit.collider.gameObject.transform.position;
            }
            else
            {
                Debug.Log(_rayCastHit.collider.name);
            }
        }
        
    }
}
