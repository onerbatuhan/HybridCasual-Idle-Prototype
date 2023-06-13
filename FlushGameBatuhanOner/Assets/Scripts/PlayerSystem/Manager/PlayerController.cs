using System;
using AnimationSystem.Manager;
using GemSystem.Manager;
using PlayerSystem.Events;
using UnityEngine;

namespace PlayerSystem.Manager
{
  public class PlayerController : MonoBehaviour
  {

    public DynamicJoystick dynamicJoystick;
    public PlayerMoveEvent playerMoveEvent;
    public bool canPlay;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Animator animator;
   
    private void Awake()
    {
      rigidBody = GetComponent<Rigidbody>();
      animator = GetComponent<Animator>();
    }

    private void Update()
    {
      
      if (!canPlay) return;
      HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
      AnimationController.Instance.ChangeAnimation(AnimationType.AnimationTypes.Idle,animator);
      if (((Input.touchCount <= 0 || Input.GetTouch(0).phase != TouchPhase.Moved) && !Input.GetMouseButton(0))) return;
      playerMoveEvent.Move(dynamicJoystick, rigidBody,transform,animator);
     
      
    }

    
    

    
  }
}
