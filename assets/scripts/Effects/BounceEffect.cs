using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    [CreateAssetMenu(fileName = "bounce", menuName = "Effects/bounce")]
    public class BounceEffect : Effect
    {
        [SerializeField]
        private float amount;
        [SerializeField]
        private float duration;
        [SerializeField]
        private AnimationCurve motion;
        public override Sequence ApplyTo(GameObject target, bool playImmediately = true)
        {
            var initialScale = target.transform.localScale;
            var seq = DOTween.Sequence()
                .Append(target.transform.DOScale(initialScale + Vector3.one * amount, duration).SetEase(motion))
                .AppendCallback(() => target.transform.localScale = initialScale);
            if (playImmediately)
                seq.Play();
            return seq;
        }
    }
}
