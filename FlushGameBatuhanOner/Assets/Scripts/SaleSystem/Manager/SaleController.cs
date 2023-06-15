using System;
using SaleSystem.Events;
using UnityEngine;

namespace SaleSystem.Manager
{
    public class SaleController : MonoBehaviour
    {
       [SerializeField] private ObjectSoldEvent _objectSoldEvent;

       private void Start()
       {
           _objectSoldEvent = FindObjectOfType<ObjectSoldEvent>();
       }

       private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            _objectSoldEvent.StartCoroutine(nameof(ObjectSoldEvent.RevenueCalculation));
        }

       private void OnTriggerExit(Collider other)
       {
           if (!other.gameObject.CompareTag("Player")) return;
           _objectSoldEvent.StopCoroutine(nameof(ObjectSoldEvent.RevenueCalculation));
       }
    }
}
