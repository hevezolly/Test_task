using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    [CreateAssetMenu(fileName = "new scale from zero", menuName = "Effects/scale from zero")]
    public class ScaleFromZeroEffect : Effect
    {
        [SerializeField]
        private float duration;
        [SerializeField]
        private float overshoot;
        [SerializeField]
        private Ease ease;
        public override Sequence ApplyTo(GameObject target, bool play)
        {
            var initialScale = target.transform.localScale;
            var seq = DOTween.Sequence()
                .AppendCallback(() => target.transform.localScale = Vector3.zero)
                .Append(target.transform.DOScale(initialScale, duration).SetEase(ease, overshoot));
            if (play)
                seq.Play();
            return seq;
        }
    }
}
