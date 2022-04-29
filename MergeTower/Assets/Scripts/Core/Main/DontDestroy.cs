using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
