using System;
using System.Collections.Generic;
using AudioSystem.Manager;
using DataSaveSystem.Manager;
using GameSystem.Manager;
using GemSystem.Manager;
using PopUpSystem.Events;
using UnityEngine;

namespace PopUpSystem.Manager
{
    public class PopUpController : MonoBehaviour
    {
        private Dictionary<string, int> _gemCounts = new Dictionary<string, int>();
        private bool isClicked = false;
        public GameObject popUpObject;
        public GameObject popUpContentObject;
        public Transform popUpParentReference;
        public List<PopUpContent> popUpContentsObjectList;
        private UIScaleEffects uIScaleEffects;
        private void Start()
        {
            uIScaleEffects = FindObjectOfType<UIScaleEffects>();
        }

        public void PopUpButtonClicked()
        {
            if (!isClicked)
            {
                DataController.Instance.DataLoad(_gemCounts, GameController.GemCountKeyPrefix);

                foreach (var gemData in GemDataAccessController.Instance.gemDataList)
                {
                    if (_gemCounts.TryGetValue(gemData.gemName, out int gemCount))
                    {
                        GameObject cloneContentObject = Instantiate(popUpContentObject, popUpParentReference);
                        PopUpContent popUpContent = cloneContentObject.GetComponent<PopUpContent>();
                        popUpContent.ObjectValuePrint(gemData.gemName, gemCount, gemData.gemIcon);
                        popUpContentsObjectList.Add(popUpContent);
                    }
                    else
                    {
                        GameObject cloneContentObject = Instantiate(popUpContentObject, popUpParentReference);
                        PopUpContent popUpContent = cloneContentObject.GetComponent<PopUpContent>();
                        popUpContent.ObjectValuePrint(gemData.gemName, 0, gemData.gemIcon);
                        popUpContentsObjectList.Add(popUpContent);
                    }
                }

                isClicked = true;
            }
            else
            {
                PopUpContentsUpdate();
            }
            
            popUpObject.SetActive(true);
            AudioController.Instance.popUpClicked.Play();
            uIScaleEffects.OnEnableAnimation(popUpObject.transform);
        }

        public void PopUpButtonBackClicked()
        {
            AudioController.Instance.popUpBackClicked.Play();
            popUpObject.SetActive(false);
        }
        private void PopUpContentsUpdate()
        {
            DataController.Instance.DataLoad(_gemCounts, GameController.GemCountKeyPrefix);
            foreach (var popUpContent in popUpContentsObjectList)
            {
                foreach (var (key, value) in _gemCounts)
                {
                    if (popUpContent.objectNameText.text == key)
                    {
                        popUpContent.collectedObjectTotalCountText.text = value.ToString();
                    }
                    
                }
            }
        }
    }
}
