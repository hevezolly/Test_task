using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Containers;
using Grid;
using DisplayedObjects;
using DG.Tweening;

namespace GameProgress
{
    public class LevelUpdator : MonoBehaviour, IAnswerChecker, ILevelSetter
    {
        [SerializeField]
        private GameObject gridHolder;

        [SerializeField]
        private IContainerEvent incorrectSelectEvent;

        [SerializeField]
        private IContainerEvent correctSelectEvent;

        [SerializeField]
        private IDisplayObjectEvent setAnswerEvent;

        private IGrid grid;
        private IContainerProvider gridContent;

        private void Awake()
        {
            grid = gridHolder.GetComponent<IGrid>();
            gridContent = gridHolder.GetComponent<IContainerProvider>();
        }

        private IDisplayedObject answer;

        private List<IDisplayedObject> allObjects;

        public IContainerEvent IncorrectSelectEvent => incorrectSelectEvent;

        public IContainerEvent CorrectSelectEvent => correctSelectEvent;

        public IDisplayObjectEvent SetAnswerEvent => setAnswerEvent;

        public void SetNewLevel(ILevel level)
        {
            GetDisplayData(level);
            UpdateGrid(level);
        }

        private void GetDisplayData(ILevel level)
        {
            allObjects = new List<IDisplayedObject>(level.GetDataSet().GetDisplayedSet(out answer,
                level.Dimentions.x * level.Dimentions.y));
            SetAnswerEvent?.Invoke(answer);
        }

        private void UpdateGrid(ILevel level)
        {
            var gridCreationSeq = grid.UpdateGridDimentions(level.Dimentions, level.levelChangeEffec);
            var objectIndex = 0;
            for (var y = grid.Dimentions.y - 1; y >= 0; y--)
            {
                for (var x = 0; x < grid.Dimentions.x; x++)
                {
                    var container = gridContent.GetContainer(new Vector2Int(x, y));
                    allObjects[objectIndex].AssignToContainer(container);
                    objectIndex++;
                }
            }
            gridCreationSeq.Play();
        }

        public void CheckAnswer(IContainer container)
        {
            if (ReferenceEquals(container.Content, answer))
                correctSelectEvent?.Invoke(container);
            else
                incorrectSelectEvent?.Invoke(container);
        }
    }
}
