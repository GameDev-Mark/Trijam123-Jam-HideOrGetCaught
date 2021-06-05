using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    Transform parentTransform;

    Light changeLightColor;

    bool _canSeeWalls;

    float timerCheckColl_max;
    float timerCheckColl_min;
    float timerCheckColl_count;

    void Start()
    {
        parentTransform = GetComponentInParent<Transform>().parent;
        changeLightColor = GetComponent<Light>();

        _canSeeWalls = false;
        timerCheckColl_max = 1f;
        timerCheckColl_min = 0f;
        timerCheckColl_count = 1f;
    }

    private void Update()
    {
        if(_canSeeWalls == true)
        {
            timerCheckColl_count -= Time.deltaTime;
            if(timerCheckColl_count <= timerCheckColl_min)
            {
                _canSeeWalls = false;
                GetComponent<BoxCollider>().enabled = enabled;
                timerCheckColl_count = timerCheckColl_max;
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            parentTransform.LookAt(collider.transform);
            changeLightColor.color = new Color(225, 0, 0, 225); // red color
        }

        if(collider.gameObject.CompareTag("Walls"))
        {
            GetComponent<BoxCollider>().enabled = !enabled;
            _canSeeWalls = true;
            Debug.Log("WALLS UP");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            changeLightColor.color = new Color(225, 225, 225, 225); // white color
            Debug.Log("white");
        }
    }
}
