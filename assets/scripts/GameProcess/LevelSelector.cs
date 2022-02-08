using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProgress
{
    public class LevelSelector : GameState, ILevelProvider
    {
        [SerializeField]
        private List<Level> levels;

        private int currentLevel = -1;

        protected override ILevelProvider levelProvider => this;

        private void Start()
        {
            Restart();
            CurrentLevelCompleted();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CurrentLevelCompleted();
            }
        }

        public void StartFromFirst()
        {
            currentLevel = -1;
        }

        public bool TryGetNextDataSet(out ILevel dataSet)
        {
            dataSet = null;
            if (++currentLevel >= levels.Count)
                return false;
            dataSet = levels[currentLevel];
            return true;
        }
    }
}
