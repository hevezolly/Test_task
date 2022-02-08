using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Effects
{
    public interface IEffect
    {
        Sequence ApplyTo(GameObject target, bool playImmediately = true);
    }

    public abstract class Effect : ScriptableObject, IEffect
    {
        public abstract Sequence ApplyTo(GameObject target, bool playImmediately = true);
    }
}
