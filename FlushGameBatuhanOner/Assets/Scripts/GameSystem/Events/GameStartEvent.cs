using System;
using System.Collections.Generic;
using AnimationSystem.Manager;
using Cinemachine;
using PlayerSystem.Manager;
using UnityEditor.Animations;
using UnityEngine;

namespace GameSystem.Events
{
    public class GameStartEvent : MonoBehaviour
    {
        public List<GameObject> hiddenObjects;
        public List<GameObject> visibleObject;
        public Transform playerObject;
        public CinemachineVirtualCamera cineMachineCamera;
        private PlayerController playerController;
        private Animator playerAnimator;
        private void Awake()
        { 
            playerController = playerObject.GetComponent<PlayerController>();
            playerAnimator = playerObject.GetComponent<Animator>();
            playerController.canPlay = false;
            AnimationController.Instance.ChangeAnimation(AnimationType.AnimationTypes.Dance,playerAnimator);
        }

        public void StartButtonClicked()
        {
            foreach (var hiddenObject in hiddenObjects)
            {
                hiddenObject.SetActive(false);
            }

            foreach (var visibleObj in visibleObject)
            {
                visibleObj.SetActive(true);
            }
           
            playerObject.rotation = Quaternion.identity;
            playerController.canPlay = true;
            AnimationController.Instance.ChangeAnimation(AnimationType.AnimationTypes.Idle,playerAnimator);
            cineMachineCamera.Priority = 0;
        }
    }
}
