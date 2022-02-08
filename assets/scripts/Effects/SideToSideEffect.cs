using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    [CreateAssetMenu(fileName = "sideToSideEffect", menuName = "Effects/side to side")]
    public class SideToSideEffect : Effect
    {
        [SerializeField]
        private float duration;

        [SerializeField]
        private float amplitude;

        [SerializeField]
        private AnimationCurve movement;

        public override Sequence ApplyTo(GameObject target, bool playImmediately = true)
        {
            var initialPos = target.transform.position;
            var seq = DOTween.Sequence()
                .Append(target.transform.DOMoveX(target.transform.position.x + amplitude, duration).SetEase(movement))
                .AppendCallback(() => target.transform.position = initialPos);
            if (playImmediately)
                seq.Play();
            return seq;
        }
    }
}
