using DesignPatterns;
using DG.Tweening;
using GameSystem.Manager;
using TMPro;
using UnityEngine;


namespace SaleSystem.Events
{
    public class SalesScreenUIEvent : MonoBehaviour
    {
        public Transform moneyBarPosition;
        public ObjectPooler objectPooler;
        public TextMeshProUGUI moneyTextUI;

        public void MoveUIObjectToTargetPosition(GameObject targetWorldObject)
        {
            GameObject objectToConverted = objectPooler.GetObject();
            Vector3 newPosition = new Vector3(targetWorldObject.transform.position.x, 0, targetWorldObject.transform.position.z);
            objectToConverted.transform.localScale = Vector3.zero;
            objectToConverted.transform.position = newPosition;
            objectToConverted.transform.SetParent(moneyBarPosition.transform);
            objectToConverted.transform.position = Camera.main.WorldToScreenPoint(objectToConverted.transform.position);
            objectToConverted.transform.DOScale(1.7f, .5f);
            objectToConverted.transform.DOMove(moneyBarPosition.position, 1f).OnComplete(() => objectPooler.ReleaseObject(objectToConverted));
        }

        public void PrintTheEarningText()
        {
            moneyTextUI.text = GameController.Instance.gameTotalEarningsValue.ToString();
           
        }
    }
}