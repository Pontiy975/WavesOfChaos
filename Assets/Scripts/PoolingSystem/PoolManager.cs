using UnityEngine;

namespace PoolingSystem
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private PoolController[] controllers;

        private void Awake()
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                controllers[i].Init();
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                controllers[i].Clear();
            }
        }
    }
}