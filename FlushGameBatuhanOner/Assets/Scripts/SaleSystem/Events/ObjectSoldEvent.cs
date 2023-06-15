using System;
using System.Collections;
using System.Collections.Generic;
using AudioSystem.Manager;
using DataSaveSystem.Manager;
using GameSystem.Manager;
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
      
      public IEnumerator ExecuteSalesProcess()
      {
         List<GameObject> saledObjectList = _playerStacking.gemStack;
         
         for (int i = saledObjectList.Count - 1; i >= 0; i--)
         {
            yield return new WaitForSeconds(.1f);

            if (i >= saledObjectList.Count) continue;
            GameObject currentSaledObject = saledObjectList[i];
            ObjectDestruction(currentSaledObject);
            CalculateEarnings(currentSaledObject);
            SalesScreenAnimationStart(currentSaledObject);
            AudioController.Instance.gemSaleSound.Play();
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
         _salesScreenUIEvent.PrintTheEarningText(); 
      }

      private void CalculateEarnings(GameObject currentSaleObject)
      {
         GemController gemController = currentSaleObject.GetComponent<GemController>();
         DataController.Instance.DataSave(DataController.Instance.DataLoad(GameController.EarningKey)+gemController.finalSaleValue, GameController.EarningKey);
         GameController.Instance.gameTotalEarningsValue += gemController.finalSaleValue;
         
      }
      
   }
}
