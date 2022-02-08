using Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CustomInput;

namespace Grid
{
    public class GameObjectGridCell : MonoBehaviour, IGridCell
    {
        [SerializeField]
        private GameObjectContainer container;

        [SerializeField]
        private InputProvider inputProvider;
        public IContainer Container => container;

        [SerializeField]
        private SpriteRenderer cellContent;

        private Vector2 size;

        [SerializeField]
        private IContainerEvent onCellTap;

        public IContainerEvent CellTapEvent => onCellTap;

        private void OnEnable()
        {
            inputProvider.TapEvent.AddListener(OnScreenTap);
        }

        private void OnDisable()
        {
            inputProvider.TapEvent.RemoveListener(OnScreenTap);
        }

        public void SetSize(Vector2 size)
        {
            this.size = size;
            var spriteRealSize = new Vector2(cellContent.sprite.texture.width, cellContent.sprite.texture.height) 
                / cellContent.sprite.pixelsPerUnit;
            cellContent.transform.localScale = Vector2.Scale(size, new Vector2(1 / spriteRealSize.x, 1 / spriteRealSize.y));
            container.OnResize(cellContent.transform.localScale);
        }

        public void SetPosition(Vector2 pos)
        {
            transform.localPosition = pos;
        }

        private void OnScreenTap(Vector2 position)
        {
            var realSize = Vector2.Scale(size, transform.localScale);
            if (position.x < transform.position.x + realSize.x / 2 &&
                position.x > transform.position.x - realSize.x / 2 &&
                position.y < transform.position.y + realSize.y / 2 &&
                position.y > transform.position.y - realSize.y / 2)
                onCellTap?.Invoke(Container);
        }
    }
}
