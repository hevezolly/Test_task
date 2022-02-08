using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DisplayedObjects;
using TMPro;
using UnityEngine.UI;
using GameProgress;
using DG.Tweening;

namespace Effects {

    public class TextDisplay : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI text;

        [SerializeField]
        private float fadeInTime;

        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField]
        private string textPrompt;

        private ILevel currentLevel;

        [SerializeField]
        private string replacementString = "_";

        private Sequence fadeSeq;

        public void UpdateLevel(ILevel level)
        {
            currentLevel = level;
        }
        public void SetText(IDisplayedObject answer)
        {
            text.text = textPrompt.Replace(replacementString, answer.Prompt);
            if (currentLevel.FadeInLetters)
            {
                canvasGroup.alpha = 0f;
                fadeSeq = DOTween.Sequence()
                    .Append(DOTween.To(() => canvasGroup.alpha, (v) => canvasGroup.alpha = v, 1f, fadeInTime));
                fadeSeq.Play();
            }
            else
            {
                canvasGroup.alpha = 1f;
            }
        }

        public void SetTransparent()
        {
            canvasGroup.alpha = 0;
        }

        private void OnDestroy()
        {
            fadeSeq?.Kill();
        }
    }
}
