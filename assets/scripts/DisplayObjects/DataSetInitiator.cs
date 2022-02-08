using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DisplayedObjects {
    public class DataSetInitiator : MonoBehaviour
    {
        [SerializeField]
        private List<DataSet> dataSets;
        private void Awake()
        {
            foreach (var d in dataSets)
            {
                d.Recalculate();
            }
        }
    }
}
