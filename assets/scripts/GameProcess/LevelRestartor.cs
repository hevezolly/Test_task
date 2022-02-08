using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using GameProgress;
using Grid;
using UnityEngine.Events;
using CustomInput;

namespace Effects {
    public class LevelRestartor : MonoBehaviour
    {
        [SerializeField]
        private InputProvider input;
        [SerializeField]
        private float loadingFadeTime;
        [SerializeField]
        private float partialFadeTime;

        [SerializeField]
        [Range(0, 1)]
        private float fadePercent;

        [SerializeField]
        private Image loadingImage;

        [SerializeField]
        private Image partialFadeImage;

        [SerializeField]
        private Image buttonImage;

        [SerializeField]
        private Button button;

        [SerializeField]
        private GameObject gameStateHolder;
        [SerializeField]
        private GameObject gridHolder;

        [SerializeField]
        private UnityEvent gameRestartEvent;

        private Sequence fadeSeq;

        private IGameState gameState;
        private IGrid grid;

        private void Awake()
        {
            gameState = gameStateHolder.GetComponent<IGameState>();
            grid = gridHolder.GetComponent<IGrid>();
        }

        public void OnFinalLevelFinished()
        {
            input.Block();
            fadeSeq = DOTween.Sequence()
                .Append(DOTween.To(() => partialFadeImage.color.a, (v) => SetImageAlpha(partialFadeImage, v), fadePercent, partialFadeTime))
                .Join(DOTween.To(() => buttonImage.color.a, (v) => SetImageAlpha(buttonImage, v), 1, partialFadeTime))
                .AppendCallback(() => button.interactable = true);
            fadeSeq.Play();
        }

        public void OnRestart()
        {
            button.interactable = false;
            fadeSeq = DOTween.Sequence()
                .Append(DOTween.To(() => loadingImage.color.a, (v) => SetImageAlpha(loadingImage, v), 1f, loadingFadeTime))
                .AppendCallback(() =>
                {
                    gameState.Restart();
                    grid.UpdateGridDimentions(Vector2Int.zero, null);
                    SetImageAlpha(buttonImage, 0);
                    SetImageAlpha(partialFadeImage, 0);
                    gameRestartEvent?.Invoke();
                })
                .Append(DOTween.To(() => loadingImage.color.a, (v) => SetImageAlpha(loadingImage, v), 0f, loadingFadeTime))
                .AppendCallback(() => 
                {
                    gameState.CurrentLevelCompleted();
                    input.Unblock();
                });
            fadeSeq.Play();
        }

        private void SetImageAlpha(Image im, float alpha)
        {
            im.color = new Color(im.color.r, im.color.g, im.color.b, alpha);
        }

        private void OnDestroy()
        {
            fadeSeq?.Kill();
        }
    }
}
