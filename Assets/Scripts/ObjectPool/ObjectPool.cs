using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public readonly Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();

    public GameObject GetObject(GameObject go) 
    {
        if (pool.TryGetValue(go.name, out Queue<GameObject> objectQueue))
        {
            if (objectQueue.Count == 0)
            {
                return CreateObject(go);
            }
            else
            {
                GameObject reqGO = objectQueue.Dequeue();
                reqGO.SetActive(true);
                return reqGO;
            }
        }
        else
        {
            return CreateObject(go);
        }
    }

    public void ReturnObject(GameObject go)
    {
        if (pool.TryGetValue(go.name, out Queue<GameObject> objectQueue))
        {
            objectQueue.Enqueue(go);
        }
        else
        {
            Queue<GameObject> newObjectQueue = new Queue<GameObject>();
            newObjectQueue.Enqueue(go);
            pool.Add(go.name, newObjectQueue);
        }
    }

    private GameObject CreateObject(GameObject go)
    {
        GameObject newGO = Instantiate(go);
        newGO.name = go.name;

        return newGO;
    }

}
