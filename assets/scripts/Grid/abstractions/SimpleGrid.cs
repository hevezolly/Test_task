using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containers;
using Effects;
using DG.Tweening;
using CustomInput;

namespace Grid {
    public abstract class SimpleGrid<G> : MonoBehaviour, IGrid, IContainerProvider
        where G: IGridCell
    {
        [SerializeField]
        private InputProvider input;
        protected abstract Vector2 GridCellSize { get; }

        private Dictionary<Vector2Int, G> cells = new Dictionary<Vector2Int, G>();

        public Vector2Int Dimentions { get; private set; } = Vector2Int.zero;

        protected abstract ICellProvider<G> cellProvider { get; }

        protected abstract ICellDestructor<G> cellDestructor { get; }

        public IContainer GetContainer(Vector2Int position)
        {
            return cells[position].Container;
        }

        public Sequence UpdateGridDimentions(Vector2Int newDimentions, IEffect effect)
        {
            var newCells = new Dictionary<Vector2Int, G>();
            var creationSequence = DOTween.Sequence();
            input.Block();
            for (var y = Mathf.Max(newDimentions.y, Dimentions.y) - 1; y >= 0 ; y--)
            {
                for (var x = 0; x < Mathf.Max(newDimentions.x, Dimentions.x); x++)
                {
                    var cord = new Vector2Int(x, y);
                    var position = CellCoordinateToPosition(cord, newDimentions);
                    if (x < Dimentions.x && y < Dimentions.y)
                    {
                        newCells[cord] = cells[cord];
                        newCells[cord].SetPosition(position);
                    }
                    else
                    {
                        newCells[cord] = cellProvider.CreateCell(out var createCellSeq, position, GridCellSize, effect);
                        creationSequence.Append(createCellSeq);
                    }
                    if (x >= newDimentions.x || y >= newDimentions.y)
                        cellDestructor.Destruct(cells[cord]);
                }
            }
            creationSequence.AppendCallback(() => input.Unblock());
            cells = newCells;
            Dimentions = newDimentions;
            return creationSequence;
        }

        protected abstract Vector2 CellCoordinateToPosition(Vector2Int cord, Vector2Int dimentions);
    }
}
