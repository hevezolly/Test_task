using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CustomInput {
    public class InputEventActivator : MonoBehaviour
    {
        [SerializeField]
        private InputProvider provider;

        [SerializeField]
        private bool useMouse;

        [SerializeField]
        private Camera mainCamera;

        // Update is called once per frame
        void Update()
        {
            if (useMouse)
            {
                UpdateMouse();
            }
            else
            {
                UpdateTouch();
            }
        }

        private void UpdateTouch()
        {
            if (Input.touchCount < 1)
                return;
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                provider.Tap(mainCamera.ScreenToWorldPoint(touch.position));
            }
        }

        private void UpdateMouse()
        {
            if (Input.GetMouseButtonDown(0))
            {
                provider.Tap(mainCamera.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}
