using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CustomInput
{
    public interface ITapProvider
    {
        Vector2Event TapEvent { get; }

        void Block();

        void Unblock();
    }
}
