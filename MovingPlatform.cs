using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 endPosition;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(
            startPosition,
            endPosition,
            Mathf.PingPong(Time.deltaTime / 3, 1)
        );
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            collider.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            collider.transform.parent = null;
        }
    }
}
