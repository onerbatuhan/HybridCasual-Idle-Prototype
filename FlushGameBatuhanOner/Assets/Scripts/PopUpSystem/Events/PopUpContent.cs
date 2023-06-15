using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PopUpSystem.Events
{
    public class PopUpContent : MonoBehaviour
    {
        public TextMeshProUGUI objectNameText;
        public TextMeshProUGUI collectedObjectTotalCountText;
        public Image objectImageUI;

        public void ObjectValuePrint(string currentObjectName,int collectedObjectTotalCount,Sprite objectImage)
        {
            objectNameText.text = currentObjectName;
            collectedObjectTotalCountText.text = collectedObjectTotalCount.ToString();
            objectImageUI.sprite = objectImage;
        }
    }
}
