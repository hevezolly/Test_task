using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containers;

namespace DisplayedObjects
{
    [CreateAssetMenu(fileName = "new modifiable display object", menuName = "Display Objects/Modifiable")]
    public class ModifiableDisplayObjec : SimpleDisplayObject
    {
        [SerializeField]
        private List<DisplayModifier> modifiers;

        protected override void SetSprite(IContainer container)
        {
            foreach (var m in modifiers)
            {
                m.Modify(container);
            }
            base.SetSprite(container);
        }
    }
}
