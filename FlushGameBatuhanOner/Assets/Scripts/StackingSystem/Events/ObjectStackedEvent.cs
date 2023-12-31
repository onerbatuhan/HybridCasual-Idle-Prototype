using System;
using System.Collections;
using System.Collections.Generic;
using AudioSystem.Manager;
using DataSaveSystem.Manager;
using DesignPatterns;
using GameSystem.Manager;
using GemSystem.Tables;
using UnityEngine;

namespace StackingSystem.Events
{
    public class ObjectStackedEvent : MonoBehaviour
    {
        private Dictionary<string, int> _gemCounts = new Dictionary<string, int>();
        
        public ObjectPooler objectPooler;
        private void Start()
        {
            DataController.Instance.DataLoad(_gemCounts,GameController.GemCountKeyPrefix);
        }

        public void PerformStackedEvent(GemData stackedGemObjectData,Transform stackedGemObjectTransform)
        {
            CountCollectedGemsByType(stackedGemObjectData.gemName);
            TriggerParticleEffect(stackedGemObjectTransform);
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
           
            DataController.Instance.DataSave(_gemCounts,GameController.GemCountKeyPrefix);
        }
        
        private void TriggerParticleEffect(Transform currentGemTransform)
        {
           GameObject particleEffectObject = objectPooler.GetObject();

           foreach (Transform child in particleEffectObject.transform)
           {
               ParticleSystem particleSystem = child.GetComponent<ParticleSystem>();
               if (particleSystem == null) continue;
               var particleSystemMain = particleSystem.main;
               particleSystemMain.startColor = currentGemTransform.gameObject.GetComponent<MeshRenderer>().material.color;
           }
           particleEffectObject.transform.position = currentGemTransform.position;
           StartCoroutine("ParticleEffectPoolEnqueue",particleEffectObject);
           
        }
        private void PlaySoundEffect()
        {
            AudioController.Instance.gemStackedSound.Play();
        }

        private IEnumerator ParticleEffectPoolEnqueue(GameObject particleEffectObject)
        {
            ParticleSystem particleSystem = particleEffectObject.GetComponent<ParticleSystem>();
            yield return new WaitForSeconds(particleSystem.main.duration);
            objectPooler.ReleaseObject(particleEffectObject);
        }
        
    }
}
