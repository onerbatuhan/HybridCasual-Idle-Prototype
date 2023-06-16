using System.Collections.Generic;
using DG.Tweening;
using GameSystem.Manager;
using UnityEngine;

namespace StackingSystem.Events
{
    public class PlayerStackingEvent : MonoBehaviour
    {
        public Transform stackStartPosition;
        public float stackHeightOffset = 1.0f;

        public List<GameObject> gemStack = new List<GameObject>();

        private GameSettings gameSettings;

        private void Start()
        {
            gameSettings = GameSettings.Instance;
        }

        public void VerticalStackEvent(GameObject currentGemObject)
        {
            currentGemObject.transform.DOKill();
            Rigidbody currentGemRigidbody = currentGemObject.GetComponent<Rigidbody>();
            currentGemRigidbody.constraints = RigidbodyConstraints.FreezeAll;

            currentGemObject.transform.SetParent(stackStartPosition);
            currentGemObject.transform.position = stackStartPosition.position;

            float jumpDistanceY = gemStack.Count * gameSettings.stackedObjectJumpDistanceYAxis;
            float jumpDistanceZ = gameSettings.stackedObjectJumpDistanceZAxis;

            currentGemObject.transform.DOLocalJump(new Vector3(0, jumpDistanceY, jumpDistanceZ), 1, 1, gameSettings.stackedObjectJumpTime)
                .OnComplete(() =>
                {
                    float moveDistanceY = gemStack.Count * gameSettings.stackedObjectMoveDistanceYAxis;
                    currentGemObject.transform.DOLocalMove(new Vector3(0, moveDistanceY, 0), gameSettings.stackedObjectMoveTime);
                    gemStack.Add(currentGemObject);
                });
        }
    }
}