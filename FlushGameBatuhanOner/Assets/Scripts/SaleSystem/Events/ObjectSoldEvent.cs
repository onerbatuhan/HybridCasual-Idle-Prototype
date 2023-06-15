using System;
using System.Collections;
using System.Collections.Generic;
using GemSystem.Manager;
using StackingSystem.Events;
using UnityEngine;

namespace SaleSystem.Events
{
   public class ObjectSoldEvent : MonoBehaviour
   {
     [SerializeField] private PlayerStackingEvent _playerStacking;
     [SerializeField] private SalesScreenUIEvent _salesScreenUIEvent;
      private void Start()
      {
         _playerStacking = FindObjectOfType<PlayerStackingEvent>();
         _salesScreenUIEvent = FindObjectOfType<SalesScreenUIEvent>();
      }

      public IEnumerator RevenueCalculation()
      {
         List<GameObject> saledObjectList = _playerStacking.gemStack;
         
         for (int i = saledObjectList.Count - 1; i >= 0; i--)
         {
            yield return new WaitForSeconds(.1f);

            if (i >= saledObjectList.Count) continue;
            GameObject currentSaledObject = saledObjectList[i];
            SalesScreenAnimationStart(currentSaledObject);
            ObjectDestruction(currentSaledObject);
         }
      }
      
      private void ObjectDestruction(GameObject currentSaledObject)
      {
         _playerStacking.gemStack.Remove(currentSaledObject);
         currentSaledObject.SetActive(false);
      }

      private void SalesScreenAnimationStart(GameObject currentSaleObject)
      {
         _salesScreenUIEvent.MoveUIObjectToTargetPosition(currentSaleObject);
      }
   }
}
