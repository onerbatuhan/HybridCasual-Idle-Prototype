using DG.Tweening;
using GemSystem.Manager;
using UnityEngine;

namespace GemSystem.Events
{
    public class GemAnimationEvent : MonoBehaviour
    {
        public void GemAnimationStart(Transform currentGemTransform)
        {
            ObjectScaleTransition(currentGemTransform);
        }
        
        private void ObjectScaleTransition(Transform gemTransform)
        {
            GemController gemController = gemTransform.GetComponent<GemController>();
            gemTransform.localScale = Vector3.zero;
            gemTransform.DOScale(Vector3.one, 5).OnUpdate(() =>
            {
                if (!(gemTransform.localScale.x > .25f)) return;
                gemController.canCollected = true;

            }).OnComplete(() =>
            {
                ObjectAnimationEffectExecute(gemTransform);
            });
            
        }

        private void ObjectAnimationEffectExecute(Transform gemTransform)
        {
            gemTransform.DOMoveY(gemTransform.position.y+.5f ,1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            gemTransform.DORotate(new Vector3(0f, 360f, 0f), 3f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }
    }
}
