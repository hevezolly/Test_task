using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DisplayedObjects;

namespace Containers
{
    public interface IContainer
    {
        SpriteRenderer Renderer { get; }

        GameObject BaseGameObject { get; }

        IDisplayedObject Content { get; }

        void OnAssign(IDisplayedObject displayObject);
    }
}
