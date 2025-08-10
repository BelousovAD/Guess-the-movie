namespace Common
{
    using UnityEngine;

    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T _instance;
        
        public static T Instance
        {
            get
            {
                if (_instance is null)
                {
                    GameObject singletonObject = new(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();
                    DontDestroyOnLoad(singletonObject);
                }

                return _instance;
            }
        }
    }
}