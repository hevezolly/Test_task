using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containers;

namespace DisplayedObjects
{
    public interface IDisplayModifier
    {
        void Modify(IContainer container);
    }

    public abstract class DisplayModifier : ScriptableObject, IDisplayModifier
    {
        public abstract void Modify(IContainer container);
    }
}
