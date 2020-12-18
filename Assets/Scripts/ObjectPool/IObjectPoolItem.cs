using UnityEngine;

namespace Hoseok{
    public interface IObjectPoolItem {
        void OnRequest();

        void OnRecycle();

        void RegisterPool(ObjectPool pool);

        GameObject GetGameObject();
    }
}