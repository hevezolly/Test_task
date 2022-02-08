using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DisplayedObjects;
using DG.Tweening;
using Effects;

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
