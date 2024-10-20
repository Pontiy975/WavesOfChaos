using UnityEngine;

namespace PoolingSystem
{
    [CreateAssetMenu(fileName = "PoolController", menuName = "Scriptable Objects/Pooling System/Pool Controller")]
    public class PoolController : ScriptableObject
    {
        [SerializeField] private Pool<PoolableObject>[] pools;

        public void Init()
        {
            Transform globalContaner = new GameObject($"{name}_Container").transform;

            for (int i = 0; i < pools.Length; i++)
            {
                pools[i].Init(globalContaner);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < pools.Length; i++)
            {
                pools[i].Clear();
            }
        }

        public T GetFromPool<T>() where T : PoolableObject
        {
            Pool<PoolableObject> pool = GetPool<T>();
            if (pool == null)
                return null;

            return pool.GetItem() as T;
        }

        public void ReturnToPool<T>(T item) where T : PoolableObject
        {
            Pool<PoolableObject> pool = GetPool<T>();
            pool?.ReturnItem(item);
        }

        private Pool<PoolableObject> GetPool<T>()
        {
            for (int i = 0; i < pools.Length; i++)
            {
                if (pools[i].CheckItemType<T>())
                    return pools[i];
            }

            return null;
        }
    }
}