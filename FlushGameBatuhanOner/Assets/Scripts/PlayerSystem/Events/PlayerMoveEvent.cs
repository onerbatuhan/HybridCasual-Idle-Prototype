using AnimationSystem.Manager;
using UnityEngine;

namespace PlayerSystem.Events
{
    public class PlayerMoveEvent : MonoBehaviour
    {
        public float moveSpeed;
        public float rotateSpeed;
        [SerializeField] private const float SpeedLimit = 0.7f;
        [SerializeField] private const float MoveThreshold = 0.2f;
        private Vector3 moveVector;

        public void Move(DynamicJoystick dynamicJoystick, Rigidbody rigidBody, Transform playerTransform, Animator animator)
        {
            moveVector = new Vector3(dynamicJoystick.Horizontal, 0f, dynamicJoystick.Vertical) * moveSpeed * Time.deltaTime;
    
            if (Mathf.Abs(dynamicJoystick.Horizontal) < MoveThreshold && Mathf.Abs(dynamicJoystick.Vertical) < MoveThreshold)
            {
                ChangeAnimation(AnimationType.AnimationTypes.Idle, animator);
            }
            else
            {
                AnimationType.AnimationTypes animationType = Mathf.Abs(dynamicJoystick.Horizontal) > SpeedLimit || Mathf.Abs(dynamicJoystick.Vertical) > SpeedLimit ?
                    AnimationType.AnimationTypes.Run : AnimationType.AnimationTypes.Walk;
        
                ChangeAnimation(animationType, animator);
                RotateCharacter(playerTransform, moveVector);
                MoveCharacter(rigidBody, moveVector, animationType);
            }
        }
        
        private void ChangeAnimation(AnimationType.AnimationTypes animationType, Animator animator)
        {
            AnimationController.Instance.ChangeAnimation(animationType, animator);
        }
        
        private void RotateCharacter(Transform playerTransform, Vector3 moveVector)
        {
            Vector3 direction = Vector3.RotateTowards(playerTransform.forward, moveVector, rotateSpeed * Time.deltaTime, 0.0f);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, Quaternion.LookRotation(direction), 5);
        }
        
        private void MoveCharacter(Rigidbody rigidBody, Vector3 moveVector, AnimationType.AnimationTypes animationType)
        {
            float speedMultiplier = animationType == AnimationType.AnimationTypes.Walk ? 0.5f : 1f;
            rigidBody.MovePosition(rigidBody.position + moveVector * speedMultiplier);
        }
    }
    
}
