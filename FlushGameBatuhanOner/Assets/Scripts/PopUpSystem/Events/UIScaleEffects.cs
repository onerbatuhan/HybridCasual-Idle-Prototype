using DG.Tweening;
using UnityEngine;

namespace PopUpSystem.Events
{
    public class UIScaleEffects : MonoBehaviour
    {
        public float smallScaleY = 0.5f;
        public float largeScaleY = 1.5f;
        public float animationDuration = 0.5f;

        private RectTransform rectTransform;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            StartScaleAnimation();
        }

        private void StartScaleAnimation()
        {
            rectTransform.localScale = new Vector3(rectTransform.localScale.x, smallScaleY, rectTransform.localScale.z);
            rectTransform.DOScaleY(largeScaleY, animationDuration).SetEase(Ease.OutBounce).OnComplete(ReverseScaleAnimation);
        }

        private void ReverseScaleAnimation()
        {
            rectTransform.DOScaleY(smallScaleY, animationDuration).SetEase(Ease.InBounce).OnComplete(StartScaleAnimation);
        }

        public void OnEnableAnimation(Transform currentTransform)
        {
            currentTransform.localScale = Vector3.zero;
            currentTransform.DOScale(Vector3.one, .7F).SetEase(Ease.OutBounce);
        }
    }
}
