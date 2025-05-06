using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] private float bulletSpeed;
    private Rigidbody bulletRb;


    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody>();
    }
    


    // Update is called once per frame

    private void OnCollisionEnter(Collision colission)
    {
        if(colission.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = colission.gameObject.GetComponent<Enemy>();
            enemy.GetHit(1);
            Destroy(gameObject);
        }
        Destroy(gameObject);
        
    }
    

    public void ShootBullet(Vector3 direction)
    {
        bulletRb.velocity = direction * bulletSpeed;
        Destroy(gameObject, 2f);
    }

    
}
