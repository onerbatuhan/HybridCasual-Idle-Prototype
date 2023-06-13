using UnityEngine;

namespace DesignPatterns
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private bool dontDestroy = true;
        
        private static T _instance;

        #region Life Cycle

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;

                if (dontDestroy)
                {
                    DontDestroyOnLoad(gameObject);
                }
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }

        #endregion


        #region Pattern

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        _instance = obj.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        #endregion
    }
}

