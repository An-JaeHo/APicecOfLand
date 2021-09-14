using UnityEngine;

public class GenericSingletonClass<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;

                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = typeof(T).Name;
                    instance = container.AddComponent(typeof(T)) as T;

                    DontDestroyOnLoad(container);
                }
            }
            return instance;
        }

    }

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}