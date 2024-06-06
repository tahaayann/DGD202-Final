using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private int _collectedcoins;
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private TextMeshProUGUI _tutorial;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coins"))
        {
         _collectedcoins++;
         _coins.text = _collectedcoins.ToString();

        }else if (other.CompareTag("Projectile"))
        {
            Debug.Log("hit");
           transform.position = new Vector3(0f, 0f, 0f);
           _audioSource.PlayOneShot(_hitSound);
        }else if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Credits Scene");
        }else if (other.CompareTag("Tutorial"))
        {
            _tutorial.gameObject.SetActive(false);
        }
       
        
    }
}
