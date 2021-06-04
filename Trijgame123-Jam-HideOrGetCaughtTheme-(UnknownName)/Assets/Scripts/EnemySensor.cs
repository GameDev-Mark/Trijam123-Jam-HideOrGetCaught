using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    Transform parentTransform;
    Light changeLightColor;
    EnemyController _enemyControllerScript;

    void Start()
    {
        parentTransform = GetComponentInParent<Transform>().parent;
        changeLightColor = GetComponent<Light>();
        _enemyControllerScript = GetComponentInParent<EnemyController>();
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            parentTransform.LookAt(collider.transform);
            changeLightColor.color = new Color(225, 0, 0, 225);
            
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            changeLightColor.color = new Color(225, 225, 225, 225);
        }
    }
}
