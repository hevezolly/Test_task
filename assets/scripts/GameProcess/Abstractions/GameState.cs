using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameProgress
{
    public abstract class GameState : MonoBehaviour, IGameState
    {
        [SerializeField]
        private ILevelEvent levelSetEvent;
        public ILevelEvent NewLevelSetEvent => levelSetEvent;

        [SerializeField]
        private UnityEvent FinalLevelCompleted;

        public UnityEvent LastLevelComplitedEvent => FinalLevelCompleted;

        protected abstract ILevelProvider levelProvider { get; }

        public void Restart()
        {
            levelProvider.StartFromFirst();
        }

        public void CurrentLevelCompleted()
        {
            if (levelProvider.TryGetNextDataSet(out var nextLevel))
            {
                levelSetEvent?.Invoke(nextLevel);
            }
            else
            {
                FinalLevelCompleted?.Invoke();
            }
        }
    }
}
