using System;
using DG.Tweening;
using GemSystem.Events;
using GemSystem.Tables;
using StackingSystem.Manager;
using UnityEngine;

namespace GemSystem.Manager
{
    public class GemController : MonoBehaviour
    {
        public GemData gemData;
        public bool canCollected;
        public GemAnimationEvent gemAnimationEvent;
        public GemSpawnerEvent gemSpawnerEvent;
        public Transform gemOriginalTransform;
        private bool _canReturn = true;

        public void Start()
        {
           
            gemOriginalTransform = transform;
            gemAnimationEvent = FindObjectOfType<GemAnimationEvent>();
            gemSpawnerEvent = FindObjectOfType<GemSpawnerEvent>();
            gemAnimationEvent.GemAnimationStart(transform);
            
        }

       

        private void OnTriggerStay(Collider other)
        {
            if(!canCollected) return;
            if (!_canReturn) return;
            _canReturn = false;
            CollectGem(other);


        }
        
        private void CollectGem(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            
            StackController stackController = other.GetComponent<StackController>();
            GemDataAccessController.Instance.gemObjectList.Remove(gameObject);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.SetActive(false);
            stackController.TriggerStackedEvents(gemData,transform);
            gemSpawnerEvent.CreateGem(gemOriginalTransform,transform.parent);
            
        }
    }
}
