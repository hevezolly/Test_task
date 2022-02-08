using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containers;

namespace DisplayedObjects
{
    [CreateAssetMenu(fileName = "new rotate modifier", menuName = "Display Objects/Modifires/Rotate")]
    public class RotateModifier : DisplayModifier
    {
        [SerializeField]
        private float angle;
        public override void Modify(IContainer container)
        {
            container.BaseGameObject.transform.Rotate(Vector3.forward, angle);
        }
    }
}
