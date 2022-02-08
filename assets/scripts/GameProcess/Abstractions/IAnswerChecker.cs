using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Containers;

namespace GameProgress
{
    public interface IAnswerChecker
    {
        IContainerEvent IncorrectSelectEvent { get; }

        IContainerEvent CorrectSelectEvent { get; }

        void SetNewLevel(ILevel leve);

    }
}