using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DisplayedObjects;
using Effects;

namespace GameProgress
{
    public interface ILevel
    {
        Vector2Int Dimentions { get; }

        IDataSet GetDataSet();

        Effect levelChangeEffec { get; }

        bool FadeInLetters { get; }
    }
}
