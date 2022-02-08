using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameProgress
{
    public interface ILevelSetter
    {
        void SetNewLevel(ILevel leve);

        IDisplayObjectEvent SetAnswerEvent { get; }
    }
}