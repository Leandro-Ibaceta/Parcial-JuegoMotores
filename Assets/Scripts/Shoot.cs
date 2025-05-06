using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    private InputAction _shoot;

    private void OnEnable()
    {
        inputActions.FindActionMap("¨Player");
    }

    private void Awake()
    {
        _shoot = InputSystem.actions.FindAction("Attack");
    }

    private void Update()
    {
        if(_shoot.WasPressedThisFrame())
        {
            Bullet bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            bullet.ShootBullet(spawnPoint.forward);
        }
    }
}
