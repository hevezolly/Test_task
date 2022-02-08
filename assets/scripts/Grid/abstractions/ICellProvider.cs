using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Effects;

namespace Grid {
    public interface ICellProvider<T> where T : IGridCell
    {
        T CreateCell(out Sequence creationSeq, IEffect effect = null);
    }

    public static class ICellExtentions
    {
        public static T CreateCell<T>(this ICellProvider<T> provider, out Sequence creationSeq, 
            Vector2 position, Vector2 size, IEffect effect = null)
            where T : IGridCell
        {
            var cell = provider.CreateCell(out creationSeq, effect);
            cell.SetPosition(position);
            cell.SetSize(size);
            return cell;
        }
    }
}
