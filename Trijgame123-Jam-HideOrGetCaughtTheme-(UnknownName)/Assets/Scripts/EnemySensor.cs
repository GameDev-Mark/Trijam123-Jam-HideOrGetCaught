using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    Transform parentTransform;

    Light changeLightColor;

    bool _canSeeWalls;

    float timerCheckColl_max;
    float timerCheckColl_min;
    float timerCheckColl_count;

    Color _whiteLightC = Color.white;
    Color _redLightC = Color.red;

    void Start()
    {
        parentTransform = GetComponentInParent<Transform>().parent;
        changeLightColor = GetComponent<Light>();

        _canSeeWalls = false;
        timerCheckColl_max = 1.5f;
        timerCheckColl_min = 0f;
        timerCheckColl_count = 1.5f;
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
                changeLightColor.color = _whiteLightC; // white color
            }
        }

        if (Time.timeScale <= 0.1f)
        {
            changeLightColor.color = new Color(225, 0, 0, 225); // red color
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(_canSeeWalls == false)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                parentTransform.LookAt(collider.transform);
                changeLightColor.color = _redLightC; // red color
            }
        }

        if(collider.gameObject.CompareTag("Walls"))
        {
            GetComponent<BoxCollider>().enabled = !enabled;
            _canSeeWalls = true;
            Debug.Log("WALLS UP");
        }
    }
}
