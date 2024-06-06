using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Collider _collider;
    [SerializeField] private MeshRenderer _renderer;
    
    [SerializeField]private AudioClip _pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("aaaaa");
            _collider.enabled = false;
            _renderer.enabled = false;
            
            _audioSource.PlayOneShot(_pickupSound);
            _particle.Play();

            Invoke("DestroyObject",2f);
            
        }
    }
}
