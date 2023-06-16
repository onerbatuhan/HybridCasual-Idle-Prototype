using DG.Tweening;
using GameSystem.Manager;
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
            gemTransform.DOScale(Vector3.one, GameSettings.Instance.scaleGrowthTime).OnUpdate(() =>
            {
                if (!(gemTransform.localScale.x > GameSettings.Instance.collectibleScaleLimit)) return;
                gemController.canCollected = true;

            }).OnComplete(() =>
            {
                ObjectAnimationEffectExecute(gemTransform);
            });
            
        }

        private void ObjectAnimationEffectExecute(Transform gemTransform)
        {
            gemTransform.DOMoveY(gemTransform.position.y+GameSettings.Instance.yAxisAddValue ,GameSettings.Instance.yAxisRiseSpeed).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            gemTransform.DORotate(GameSettings.Instance.rotationAngles, GameSettings.Instance.rotationSpeed, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }
    }
}
