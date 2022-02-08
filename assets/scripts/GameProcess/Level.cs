using DisplayedObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Effects;

namespace GameProgress {
    
    [System.Serializable]
    public class Level : ILevel
    {
        [SerializeField]
        private Vector2Int dimentions;

        [SerializeField]
        private Effect changeEffec;

        [SerializeField]
        private List<DataSet> possibleDataSets;

        [SerializeField]
        private bool fadeInLetters;

        [SerializeField]
        private bool useSeed;
        [SerializeField]
        private int seed;

        private System.Random random;

        private System.Random Random 
        { 
            get
            {
                if (random == null)
                {
                    if (useSeed)
                        random = new System.Random(seed);
                    else
                        random = new System.Random();
                }
                return random;
            } 
        }

        public Vector2Int Dimentions => dimentions;

        public Effect levelChangeEffec => changeEffec;

        public bool FadeInLetters => fadeInLetters;

        public IDataSet GetDataSet()
        {
            return possibleDataSets[Random.Next(possibleDataSets.Count)];
        }
    }
}
