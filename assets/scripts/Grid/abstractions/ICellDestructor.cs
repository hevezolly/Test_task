using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public interface ICellDestructor<T> where T: IGridCell
    {
        void Destruct(T cell);
    }
}
