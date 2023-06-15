using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace StackingSystem.Events
{
    public class PlayerStackingEvent : MonoBehaviour
    {
        public Transform stackStartPosition;
        public float stackHeightOffset = 1.0f;

        public List<GameObject> gemStack = new List<GameObject>();

        public void VerticalStackEvent(GameObject currentGemObject)
        {
            currentGemObject.transform.DOKill();
            currentGemObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            currentGemObject.transform.SetParent(stackStartPosition);
            currentGemObject.transform.position = stackStartPosition.position;

            currentGemObject.transform.DOLocalJump(new Vector3(0, gemStack.Count * 1, -1), 1,1,.6f).OnComplete((() =>
            {
                currentGemObject.transform.DOLocalMove(new Vector3(0, gemStack.Count * .5f, 0), .3f);
                gemStack.Add(currentGemObject);
            }));
            
            
        }

        
    }
}