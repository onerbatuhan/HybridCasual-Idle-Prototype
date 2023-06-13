using System;
using DG.Tweening;
using GemSystem.Tables;
using UnityEngine;

namespace GemSystem.Manager
{
    public class GemController : MonoBehaviour
    {
        public GemData gemData;
        public bool canCollected;


        public void Awake()
        {
            ObjectScaleTransition();
        }

        private void ObjectScaleTransition()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, 5).OnUpdate(() =>
            {
                if (!(transform.localScale.x > .25f)) return;
                canCollected = true;
              
            }).OnComplete((ObjectAnimationEffectExecute));
        }

        private void ObjectAnimationEffectExecute()
        {
            transform.DOMoveY(transform.position.y+.5f ,1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            transform.DORotate(new Vector3(0f, 360f, 0f), 3f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }

        
    }
}
