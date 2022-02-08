using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CustomInput {
    [CreateAssetMenu(menuName = "Input provider")]
    public class InputProvider : ScriptableObject, ITapProvider
    {
        [SerializeField]
        private Vector2Event tapEvent;
        public Vector2Event TapEvent => tapEvent;

        private bool isBlocked = false;

        public void Block()
        {
            isBlocked = true;
        }

        public void Tap(Vector2 position)
        {
            if (isBlocked)
                return;
            tapEvent?.Invoke(position);
        }

        public void Unblock()
        {
            isBlocked = false;
        }
    }
}
