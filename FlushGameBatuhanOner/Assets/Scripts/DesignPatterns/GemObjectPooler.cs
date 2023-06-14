using System.Collections.Generic;
using GemSystem.Manager;
using GemSystem.Tables;
using UnityEngine;

namespace DesignPatterns
{
    public class GemObjectPooler : Singleton<GemObjectPooler>
    {
        public List<GemData> gemDataObjectList;
        public int spawnCount;
        private Queue<GameObject> objectQueue;
        public Transform parentObject;

        protected override void Awake()
        {
            gemDataObjectList = GemDataAccessController.Instance.gemDataList;
            objectQueue = new Queue<GameObject>();
            PopulateObjectPool();
        }

        private void PopulateObjectPool()
        {
            foreach (GemData obj in gemDataObjectList)
            {
                for (int i = 0; i < spawnCount; i++)
                {
                    GameObject newObj = Instantiate(obj.gemObject, parentObject, true);
                    newObj.GetComponent<GemController>().gemData = obj;
                    newObj.SetActive(false);
                    objectQueue.Enqueue(newObj);
                }
            }
        }

        public GameObject SpawnObject(Transform parentObject)
        {
            
            if (objectQueue.Count == 0)
            {
                GameObject newObj = Instantiate(gemDataObjectList[Random.Range(0, gemDataObjectList.Count)].gemObject, parentObject, true);
                newObj.SetActive(false);
                objectQueue.Enqueue(newObj);
            }
            else
            {
                GameObject spawnedObj = objectQueue.Dequeue();
                spawnedObj.SetActive(true);
                spawnedObj.transform.parent = parentObject;
                return spawnedObj;
            }

            GameObject newSpawnedObj = objectQueue.Dequeue();
            newSpawnedObj.transform.parent = parentObject;
            newSpawnedObj.SetActive(true);
            return newSpawnedObj;
        }
    }
}
