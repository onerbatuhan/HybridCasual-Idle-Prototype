using System;
using DG.Tweening;
using GemSystem.Events;
using GemSystem.Tables;
using UnityEngine;

namespace GemSystem.Manager
{
    public class GemController : MonoBehaviour
    {
        public GemData gemData;
        public bool canCollected;
        public GemAnimationEvent gemAnimationEvent;
 

        public void Awake()
        {
            gemAnimationEvent = FindObjectOfType<GemAnimationEvent>();
            gemAnimationEvent.GemAnimationStart(transform);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.transform.CompareTag("Player")) return;
            GemDataAccessController.Instance.gemObjectList.Remove(gameObject);
        }

      

        
    }
}
