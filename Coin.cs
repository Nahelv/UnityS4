using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioSource audioSource;
    MeshRenderer meshRenderer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        
    }

    void Update()
    {
        transform.Rotate(
            180f * Time.deltaTime,
            180f * Time.deltaTime,
            180f * Time.deltaTime
        );
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            meshRenderer.enabled = false;
            audioSource.Play();
            Destroy(gameObject, 1f);
        }
    }
}
