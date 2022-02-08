using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containers;

namespace DisplayedObjects
{
    [CreateAssetMenu(fileName = "new simple sprite object", menuName = "Display Objects/Simple")]
    public class SimpleDisplayObject : DisplayObject
    {
        [SerializeField]
        protected Sprite sprite;

        [SerializeField]
        protected string prompt;
        public override string Prompt => prompt;

        protected override void SetSprite(IContainer container)
        {
            container.Renderer.sprite = sprite;
        }
    }
}

