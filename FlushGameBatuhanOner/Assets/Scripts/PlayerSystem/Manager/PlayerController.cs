using System;
using GemSystem.Manager;
using PlayerSystem.Events;
using UnityEngine;

namespace PlayerSystem.Manager
{
  public class PlayerController : MonoBehaviour
  {

    public DynamicJoystick dynamicJoystick;
    public PlayerMoveEvent playerMoveEvent;
    [SerializeField] private Rigidbody rigidBody;
    public bool canPlay;
    private void Awake()
    {
      rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
      if (canPlay && (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0)))
      {
        playerMoveEvent.Move(dynamicJoystick, rigidBody,transform);
      }
    }

    
    

    
  }
}
