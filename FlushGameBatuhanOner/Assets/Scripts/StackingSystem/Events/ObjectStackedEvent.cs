using System;
using System.Collections.Generic;
using DataSaveSystem.Manager;
using GemSystem.Tables;
using UnityEngine;

namespace StackingSystem.Events
{
    public class ObjectStackedEvent : MonoBehaviour
    {
        private Dictionary<string, int> _gemCounts = new Dictionary<string, int>();
        private const string GemCountKeyPrefix = "GemCount_";
        private void Start()
        {
            DataController.Instance.DataLoad(_gemCounts,GemCountKeyPrefix);
        }

        public void PerformStackedEvent(GemData stackedGemObjectData)
        {
            CountCollectedGemsByType(stackedGemObjectData.gemName);
            TriggerParticleEffect();
            PlaySoundEffect();
        }
        private void CountCollectedGemsByType(string gemName)
        {
            if (_gemCounts.ContainsKey(gemName))
            {
                _gemCounts[gemName]++;
            }
            else
            {
                _gemCounts.Add(gemName, 1);
            }
            foreach (var kvp in _gemCounts)
            {
                Debug.Log("Toplanan " + kvp.Key + " Taş Sayısı: " + kvp.Value);
            }
            DataController.Instance.DataSave(_gemCounts,GemCountKeyPrefix);
        }
        
        private void TriggerParticleEffect()
        {
            
        }

        private void PlaySoundEffect()
        {
           
        }

       
        
    }
}
