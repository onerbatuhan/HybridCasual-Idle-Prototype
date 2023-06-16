using System;
using DesignPatterns;
using UnityEngine;

namespace AnimationSystem.Manager
{
    public class AnimationController : Singleton<AnimationController>
    {
        private static readonly int Dance = Animator.StringToHash("Dance");
        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Idle = Animator.StringToHash("Idle");

        public void ChangeAnimation(AnimationType.AnimationTypes animationTypes,Animator currentAnimator)
        {
            StopAllAnimations(currentAnimator);
            switch (animationTypes)
            {
                case AnimationType.AnimationTypes.Dance:
                    currentAnimator.SetBool(Dance,true);
                    break;
                case AnimationType.AnimationTypes.Run:
                    currentAnimator.SetBool(Run,true);
                    break;
                case AnimationType.AnimationTypes.Walk:
                    currentAnimator.SetBool(Walk,true);
                    break;
                case AnimationType.AnimationTypes.Idle:
                    currentAnimator.SetBool(Idle,true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(animationTypes), animationTypes, null);
            }
        }
        
        private static void StopAllAnimations(Animator currentAnimator)
        {
            foreach (AnimationType.AnimationTypes animationType in Enum.GetValues(typeof(AnimationType.AnimationTypes)))
            {
                string animationName = animationType.ToString();
                currentAnimator.SetBool(animationName, false);
            }
        }
    }
}
