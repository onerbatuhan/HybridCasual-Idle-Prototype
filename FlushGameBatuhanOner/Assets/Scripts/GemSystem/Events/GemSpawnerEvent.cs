using DesignPatterns;
using GemSystem.Manager;
using UnityEngine;

namespace GemSystem.Events
{
    public class GemSpawnerEvent : MonoBehaviour
    {
        public void CreateGem(Transform currentGemTransform, Transform currentGridTransform)
        {
            GameObject cloneGemObject = GemObjectPooler.Instance.SpawnObject(currentGridTransform);
            GemDataAccessController.Instance.gemObjectList.Add(cloneGemObject);
            cloneGemObject.transform.parent = currentGridTransform;

            Vector3 newPosition = currentGemTransform.position;
            newPosition.y = currentGemTransform.parent.position.y;
            cloneGemObject.transform.position = newPosition;
        }
    }
}
