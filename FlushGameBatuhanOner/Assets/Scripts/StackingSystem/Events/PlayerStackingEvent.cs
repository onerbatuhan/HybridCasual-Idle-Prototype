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
            // currentGemObject.transform.DOKill();
            // currentGemObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            // currentGemObject.transform.SetParent(stackStartPosition);
            // currentGemObject.transform.position = stackStartPosition.position;
            //
            // Vector3 newPosition = stackStartPosition.position + new Vector3(0f, gemStack.Count * stackHeightOffset, 0f);
            // currentGemObject.transform.position = newPosition;
            //
            // gemStack.Add(currentGemObject);
        }

        
    }
}