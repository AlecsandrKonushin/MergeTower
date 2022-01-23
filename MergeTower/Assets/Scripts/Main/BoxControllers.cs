using System;
using System.Collections.Generic;

public class BoxControllers : Singleton<BoxControllers>
{
    private Dictionary<Type,object> data = new Dictionary<Type, object>();

    public static void AddController(object obj)
    {
        var add = obj;
        var controller = obj as ControllerBase;

        if (controller != null)
            add = Instantiate(controller);
        else
            return;

        Instance.data.Add(obj.GetType(), add);
    }

    public static void InitControllers()
    {
        foreach (var controller in Instance.data)
        {
            var obj = controller.Value;
            if (obj is IAwake)
                (obj as IAwake).OnAwake();
        }
    }

    /// <summary>
    /// Получить controller типа Т
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetController<T>()
    {
        object resolve;
        Instance.data.TryGetValue(typeof(T), out resolve);
        return (T)resolve;
    }
}
