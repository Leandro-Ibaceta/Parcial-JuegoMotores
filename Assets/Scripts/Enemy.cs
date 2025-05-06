using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private float speed = 5;
    [SerializeField] private int health = 3;

    protected virtual void Attack()
    {
        //Ataca
    }
    private void Update()
    {
        OnDie();
    }

    private void OnDie()
    {
        //se muere y hace algo
        if(health == 0)
            Destroy(gameObject);
    }

    public void GetHit(int damage)
    {
        //recibe daño y le baja la vida
        health -= damage;
    }
}
