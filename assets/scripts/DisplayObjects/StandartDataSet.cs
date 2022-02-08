using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DisplayedObjects {
    
    [CreateAssetMenu(fileName = "new data set", menuName = "Data Set")]
    public class StandartDataSet : DataSet
    {
        [SerializeField]
        private List<DisplayObject> objectsToDisplay;

        public IEnumerable<IDisplayedObject> allDisplayObjects => objectsToDisplay.Select(o => o as IDisplayedObject);

        private HashSet<IDisplayedObject> possibleAnswers;

        private System.Random random;
        public override void Recalculate(int? seed)
        {
            possibleAnswers = new HashSet<IDisplayedObject>(objectsToDisplay);
            if (seed == null)
                random = new System.Random();
            else
                random = new System.Random(seed.Value);
        }

        public override IEnumerable<IDisplayedObject> GetDisplayedSet(out IDisplayedObject correctAnswer, int count)
        {
            var answer = GetAnswer();
            correctAnswer = answer;
            var restOfObjectsToDisplay = new List<IDisplayedObject>(objectsToDisplay.Where(o => !ReferenceEquals(o, answer)));
            var answerUsed = false;
            var answerProbability = 1f / count;
            var result = new List<IDisplayedObject>();
            for (var i = 0; i < count-1; i++)
            {
                if (!answerUsed)
                {
                    var answerValue = random.NextDouble();
                    if (answerValue <= answerProbability)
                    {
                        result.Add(answer);
                        answerUsed = true;
                        continue;
                    }       
                }
                result.Add(GetRandomObject(restOfObjectsToDisplay));
            }
            var lastObject = answer;
            if (answerUsed)
                lastObject = GetRandomObject(restOfObjectsToDisplay);
            result.Add(lastObject);
            return result;
        }

        private IDisplayedObject GetRandomObject(List<IDisplayedObject> set)
        {
            var index = random.Next(set.Count);
            return set[index];
        }

        private IDisplayedObject GetAnswer()
        {
            var element = possibleAnswers.ElementAt(random.Next(possibleAnswers.Count));
            possibleAnswers.Remove(element);
            if (possibleAnswers.Count == 0)
                possibleAnswers = new HashSet<IDisplayedObject>(objectsToDisplay);
            return element;
        }

    }
}
