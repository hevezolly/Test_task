using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containers;

namespace Grid {
    public interface IGridCell
    {
        IContainer Container { get; }

        void SetPosition(Vector2 pos);

        void SetSize(Vector2 size);
    }
}
