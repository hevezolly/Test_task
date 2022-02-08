using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProgress
{
    public interface ILevelProvider
    {
        void StartFromFirst();
        bool TryGetNextDataSet(out ILevel dataSet);
    }
}
