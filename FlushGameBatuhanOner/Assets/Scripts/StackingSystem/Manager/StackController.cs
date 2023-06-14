using System;
using StackingSystem.Events;
using UnityEngine;

namespace StackingSystem.Manager
{
    public class StackController : MonoBehaviour
    {
        [SerializeField] private ObjectStackedEvent objectStackedEvent;
        [SerializeField] private PlayerStackingEvent playerStackingEvent;
        private void Awake()
        {
            objectStackedEvent = FindObjectOfType<ObjectStackedEvent>();
            playerStackingEvent = FindObjectOfType<PlayerStackingEvent>();
        }

        public void TriggerStackedEvents()
        {
            
        }
    }
}
