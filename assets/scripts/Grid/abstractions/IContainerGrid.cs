using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containers;
using Effects;

namespace Grid
{
    public interface IGrid
    {
        Vector2Int Dimentions { get; }
        void UpdateGridDimentions(Vector2Int dimentions, IEffect effect);
    }

    public interface IContainerProvider
    {
        IContainer GetContainer(Vector2Int position);
    }
}
