using System;
using DG.Tweening;
using GameSystem.Manager;
using GemSystem.Manager;
using UnityEngine;

namespace GemSystem.Events
{
    public class GemAnimationEvent : MonoBehaviour
    {
        private GameSettings _gameSettings;
        private void Awake()
        {
            _gameSettings = GameSettings.Instance;
        }

        public void GemAnimationStart(Transform currentGemTransform)
        {
            ObjectScaleTransition(currentGemTransform);
        }
        
        private void ObjectScaleTransition(Transform gemTransform)
        {
            GemController gemController = gemTransform.GetComponent<GemController>();
            gemTransform.localScale = Vector3.zero;
            gemTransform.DOScale(Vector3.one, _gameSettings.scaleGrowthTime).OnUpdate(() =>
            {
                if (!(gemTransform.localScale.x > _gameSettings.collectibleScaleLimit)) return;
                gemController.canCollected = true;

            }).OnComplete(() =>
            {
                ObjectAnimationEffectExecute(gemTransform);
            });
            
        }

        private void ObjectAnimationEffectExecute(Transform gemTransform)
        {
            gemTransform.DOMoveY(gemTransform.position.y+_gameSettings.yAxisAddValue ,_gameSettings.yAxisRiseSpeed).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            gemTransform.DORotate(_gameSettings.rotationAngles, _gameSettings.rotationSpeed, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }
    }
}
