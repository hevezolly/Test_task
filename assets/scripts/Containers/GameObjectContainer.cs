using DisplayedObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Containers
{
    public class GameObjectContainer : MonoBehaviour, IContainer
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private GameObject baseGameObject;
        public SpriteRenderer Renderer => spriteRenderer;
        public GameObject BaseGameObject => baseGameObject;

        private IDisplayedObject displayObject;

        public IDisplayedObject Content => displayObject;

        private Vector3 initialScale;
        private Quaternion initialRotation;

        private Vector3 scaleToResetTo;

        private void Awake()
        {
            initialRotation = baseGameObject.transform.rotation;
            initialScale = baseGameObject.transform.localScale;
            scaleToResetTo = initialScale;
        }

        private void ResetBaseGameObject()
        {
            baseGameObject.transform.rotation = initialRotation;
            baseGameObject.transform.localScale = scaleToResetTo;
        }

        public void OnAssign(IDisplayedObject displayObject)
        {
            ResetBaseGameObject();
            this.displayObject = displayObject;
        }

        public void OnResize(Vector2 parentScale)
        {
            baseGameObject.transform.localScale = new Vector3(initialScale.x / parentScale.x, initialScale.y / parentScale.y);
            scaleToResetTo = baseGameObject.transform.localScale;
        }
    }
}
