using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class ObjectPooler : MonoBehaviour
    {
        public GameObject prefab;
        public int poolSize;
        public Transform parentObject;
        private Queue<GameObject> pool;

        private void Start()
        {
            pool = new Queue<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject newObj = Instantiate(prefab, transform);
                newObj.SetActive(false);
                pool.Enqueue(newObj);
                newObj.transform.SetParent(parentObject);
            }
        }

        public GameObject GetObject()
        {
            if (pool.Count > 0)
            {
                GameObject obj = pool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            
            GameObject newObj = Instantiate(prefab, transform);
            newObj.SetActive(true);
            newObj.transform.SetParent(parentObject);
            return newObj;
        }

        public void ReleaseObject(GameObject obj)
        {
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }
}
