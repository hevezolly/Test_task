using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containers;
using DG.Tweening;
using Effects;
using CustomInput;
using UnityEngine.Events;

namespace Grid {
    public class GameObjectGrid : SimpleGrid<GameObjectGridCell>,
        ICellProvider<GameObjectGridCell>, ICellDestructor<GameObjectGridCell>
    {
        [SerializeField]
        private GameObjectGridCell baseCellObject;

        [SerializeField]
        private Vector2 gridCellSize;

        [SerializeField]
        private Vector2 gridCellOffset;
        
        [SerializeField]
        private Vector2Int DisplayDimentions;
        protected override ICellProvider<GameObjectGridCell> cellProvider => this;

        protected override ICellDestructor<GameObjectGridCell> cellDestructor => this;

        [SerializeField]
        private IContainerEvent containerSelectedEvent;

        protected override Vector2 GridCellSize => gridCellSize;

        private void Start()
        {
        }

        public GameObjectGridCell CreateCell(out Sequence creationSeq, IEffect effect = null)
        {
            var cell = Instantiate(baseCellObject, transform);
            cell.gameObject.SetActive(false);
            cell.CellTapEvent.AddListener(InvokeContainerSelected);
            creationSeq = DOTween.Sequence();
            creationSeq.AppendCallback(() => cell.gameObject.SetActive(true));
            if (effect != null)
            {
                creationSeq.Append(effect.ApplyTo(cell.gameObject, false));
            }
            return cell;
        }

        private void InvokeContainerSelected(IContainer container)
        {
            containerSelectedEvent?.Invoke(container);
        }

        public void Destruct(GameObjectGridCell cell)
        {
            cell.CellTapEvent.RemoveAllListeners();
            Destroy(cell.gameObject);
        }

        protected override Vector2 CellCoordinateToPosition(Vector2Int cord, Vector2Int dimentions)
        {
            return Vector2.Scale(gridCellOffset, cord) + Vector2.Scale(gridCellSize, cord) -
                Vector2.Scale(gridCellSize + gridCellOffset, new Vector2(dimentions.x / 2, dimentions.y - 1))
                + Vector2.right * ((dimentions.x % 2 == 0) ? (gridCellSize.x + gridCellOffset.x) / 2 : 0);
        }

        private void OnDrawGizmos()
        {
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.color = Color.yellow;
            Vector2Int dim = DisplayDimentions;
            if (Application.isPlaying)
                dim = Dimentions;
            for (var y = 0; y < dim.y; y++)
            {
                for (var x = 0; x < dim.x; x++)
                {
                    var cord = new Vector2Int(x, y);
                    var blocPos = CellCoordinateToPosition(cord, dim);
                    Gizmos.DrawWireCube(blocPos, GridCellSize);
                }
            }
        }
    }
}
