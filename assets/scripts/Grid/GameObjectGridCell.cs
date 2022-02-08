using Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class GameObjectGridCell : MonoBehaviour, IGridCell
    {
        [SerializeField]
        private GameObjectContainer container;
        public IContainer Container => container;

        [SerializeField]
        private SpriteRenderer cellContent;

        public void SetSize(Vector2 size)
        {
            var spriteRealSize = new Vector2(cellContent.sprite.texture.width, cellContent.sprite.texture.height) 
                / cellContent.sprite.pixelsPerUnit;
            cellContent.transform.localScale = Vector2.Scale(size, new Vector2(1 / spriteRealSize.x, 1 / spriteRealSize.y));
        }

        public void SetPosition(Vector2 pos)
        {
            transform.localPosition = pos;
        }
    }
}
