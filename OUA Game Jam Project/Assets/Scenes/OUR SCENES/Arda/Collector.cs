using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stash))]
public class Collector : MonoBehaviour
{
    private Stash _stash;
    private AudioSource audioSource;
    private void Awake()
    {
        _stash = GetComponent<Stash>();
        audioSource = GetComponent<AudioSource>();  
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            audioSource.Play();
            if (other.TryGetComponent(out Collectable collected))
            {
                _stash.AddStash(collected);
            }
        }
    }

}
