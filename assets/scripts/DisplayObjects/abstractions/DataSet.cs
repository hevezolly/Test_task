using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DisplayedObjects {
    public interface IDataSet
    {
        IEnumerable<IDisplayedObject> GetDisplayedSet(out IDisplayedObject correctAnswer, int count);
    }

    public abstract class DataSet : ScriptableObject, IDataSet
    {
        public virtual void Recalculate(int? seed) { }
        public abstract IEnumerable<IDisplayedObject> GetDisplayedSet(out IDisplayedObject correctAnswer, int count);
    }

    public static class DataSetExtention
    {
        public static void Recalculate(this DataSet dataSet)
        {
            dataSet.Recalculate(null);
        }
    }
}
