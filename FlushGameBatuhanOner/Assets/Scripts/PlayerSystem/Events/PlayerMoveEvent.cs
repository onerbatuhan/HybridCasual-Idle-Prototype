using UnityEngine;

namespace PlayerSystem.Events
{
    public class PlayerMoveEvent : MonoBehaviour
    {
        public float moveSpeed;
        public float rotateSpeed;
        private Vector3 _moveVector;

        public void Move(DynamicJoystick dynamicJoystick, Rigidbody rigidBody,Transform playerTransform)
        {
            _moveVector.x = dynamicJoystick.Horizontal * moveSpeed * Time.deltaTime;
            _moveVector.z = dynamicJoystick.Vertical * moveSpeed * Time.deltaTime;
            if (_moveVector != Vector3.zero)
            {
                Vector3 direction = Vector3.RotateTowards(playerTransform.forward, _moveVector, rotateSpeed * Time.deltaTime, 0.0f);
                playerTransform.rotation = Quaternion.LookRotation(direction);
                // _animatorController.PlayRun();
            }
            else
            {
                // _animatorController.PlayIdle();
            }
            rigidBody.MovePosition(rigidBody.position + _moveVector);
        }
    }
}
