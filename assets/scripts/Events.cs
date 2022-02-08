using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containers;
using GameProgress;
using DisplayedObjects;

namespace UnityEngine.Events
{
    [System.Serializable]
    public class IContainerEvent : UnityEvent<IContainer> { } 

    [System.Serializable]
    public class ILevelEvent : UnityEvent<ILevel> { }

    [System.Serializable]
    public class IDisplayObjectEvent : UnityEvent<IDisplayedObject> { }

    [System.Serializable]
    public class Vector2Event : UnityEvent<Vector2> { }
}
