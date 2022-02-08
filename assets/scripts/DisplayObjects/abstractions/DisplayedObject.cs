using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containers;

namespace DisplayedObjects
{
    public interface IDisplayedObject
    {
        string Prompt { get; }
        void AssignToContainer(IContainer container);
    }

    public abstract class DisplayObject : ScriptableObject, IDisplayedObject
    {
        public abstract string Prompt { get; }

        public void AssignToContainer(IContainer container)
        {
            container.OnAssign(this);
            SetSprite(container);
        }

        protected abstract void SetSprite(IContainer container);
    }
}
