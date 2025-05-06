using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actionAsset;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private LayerMask layerMask;
    
    [SerializeField] private float speed = 8f;
   

    private InputAction _move;
    private InputAction _point;

    private Vector2 _movement;
    private Vector2 _rotate;

    private void OnEnable()
    {
        _actionAsset.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        _actionAsset.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
       
        _move = InputSystem.actions.FindAction("Move");
        _point = InputSystem.actions.FindAction("Point");
    }

    private void Update()
    {
        _movement = _move.ReadValue<Vector2>();
        _rotate = _point.ReadValue<Vector2>();
        Move();
    }

    private void FixedUpdate()
    {
        PointToMouse();
        
    }

    private void Move()
    {
        Vector3 move = new Vector3(_movement.x, 0, _movement.y);
        move.Normalize();
        playerRb.MovePosition(transform.position + move * speed * Time.deltaTime);
        
    }

    private void PointToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(_rotate);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, layerMask))
        {
            Vector3 playerToMouse = hitInfo.point - transform.position;
            playerToMouse.y = 0;

            Quaternion rotation = Quaternion.LookRotation(playerToMouse, Vector3.up);

            playerRb.MoveRotation(rotation);
            
            
        }
    }

    


}
