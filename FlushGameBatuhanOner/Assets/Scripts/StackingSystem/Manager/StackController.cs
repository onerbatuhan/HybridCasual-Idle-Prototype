using System;
using GemSystem.Tables;
using StackingSystem.Events;
using UnityEngine;

namespace StackingSystem.Manager
{
    public class StackController : MonoBehaviour
    {
         private ObjectStackedEvent  _objectStackedEvent;
         private PlayerStackingEvent _playerStackingEvent;
        private void Awake()
        {
            _objectStackedEvent = FindObjectOfType<ObjectStackedEvent>();
            _playerStackingEvent = FindObjectOfType<PlayerStackingEvent>();
        }

        public void TriggerStackedEvents(GemData currentStackedGemData)
        {
           _objectStackedEvent.PerformStackedEvent(currentStackedGemData);
        }
    }
}
