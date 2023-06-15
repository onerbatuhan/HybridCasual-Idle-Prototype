using DesignPatterns;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace SaleSystem.Events
{
    public class SalesScreenUIEvent : MonoBehaviour
    {
        public Transform moneyBarPosition;
        public ObjectPooler objectPooler;

        public void MoveUIObjectToTargetPosition(GameObject targetWorldObject)
        {
            // Objenin güncel pozisyonunu alarak UI'nın pozisyonunu güncelle
            GameObject objectToConverted = objectPooler.GetObject();
            // objectToConverted.transform.SetParent(moneyBarPosition);
            // Vector3 uiPosition = Camera.main.WorldToScreenPoint(targetWorldObject.transform.position);
            // objectToConverted.transform.localPosition = uiPosition; // LocalPosition kullan
            // // UI'yı GoldBar UI'ın pozisyonuna göndermek için MoveToPosition fonksiyonunu çağır
            // Vector3 targetPosition = Camera.main.WorldToScreenPoint(moneyBarPosition.position);
            // objectToConverted.transform.DOMove(targetPosition, 1f);
            var position = targetWorldObject.transform.position;
            Vector3 newPosition = new Vector3(position.x, 0, position.z);
            objectToConverted.transform.localScale = Vector3.zero;
            objectToConverted.transform.position =  newPosition;
            objectToConverted.transform.SetParent(moneyBarPosition.transform);
            objectToConverted.transform.position = Camera.main.WorldToScreenPoint(objectToConverted.transform.position);
            objectToConverted.transform.DOScale(1.7f, .5f);
            objectToConverted.transform.DOMove(moneyBarPosition.transform.position, 1f).OnComplete(() =>
            {
               
                    
                objectPooler.ReleaseObject(objectToConverted);
            });
          
        }
    }
}
