using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameProgress {
    public interface IGameState
    {
        ILevelEvent NewLevelSetEvent { get; }

        UnityEvent LastLevelComplitedEvent { get; }

        void Restart();

        void CurrentLevelCompleted();
    }
}
