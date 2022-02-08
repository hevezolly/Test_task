using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Containers;
using CustomInput;
using DG.Tweening;

namespace Effects 
{
    public class EffectsPlayer : MonoBehaviour
    {
        [SerializeField]
        private InputProvider input;
        [SerializeField]
        private Effect correctEffect;
        [SerializeField]
        private Effect incorrectEffect;
        [SerializeField]
        private GameObject partikles;

        [SerializeField]
        private UnityEvent CorrectSequenceFinished;

        public void OnIncorrectSelect(IContainer container)
        {
            input.Block();
            var s = incorrectEffect.ApplyTo(container.BaseGameObject, false);
            s.AppendCallback(() => input.Unblock());
            s.Play();
        }

        public void OnCorrectSelect(IContainer container)
        {
            input.Block();
            var s = correctEffect.ApplyTo(container.BaseGameObject, false);
            Instantiate(partikles, container.BaseGameObject.transform.position, Quaternion.identity);
            s.AppendCallback(() => 
            { 
                input.Unblock();
                CorrectSequenceFinished?.Invoke();
            });
            s.Play();
        }
    }
}
