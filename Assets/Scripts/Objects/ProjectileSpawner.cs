using System.Collections;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float spawnInterval = 1f;
    public float speed = 10f;
    public float projectileTime = 3f;

    private void Start()
    {
        InvokeRepeating("SpawnProjectile", 0f, spawnInterval);
    }

    void SpawnProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody projectileRb = newProjectile.GetComponent<Rigidbody>();
        if (projectileRb != null)
        {
            // Objeye bir kuvvet uygulama
            projectileRb.velocity = transform.forward * speed;
            // Oluşturulan projectile'ın ömrünün sonunda kendini yok etme
            Destroy(newProjectile, projectileTime);
        }
    }
}