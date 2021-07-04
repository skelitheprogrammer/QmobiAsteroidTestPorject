using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    private Camera _camera;

    private readonly List<Wrappable> wrappables = new List<Wrappable>();

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        TryWrap();
    }

    public void RegisterWrappable(Wrappable wrappable)
    {
        if (wrappables.Contains(wrappable)) return;

        wrappables.Add(wrappable);
    }

    public void UnRegisterWrappable(Wrappable wrappable)
    {
        if (!wrappables.Contains(wrappable)) return;

        wrappables.Remove(wrappable);
    }

    private void TryWrap()
    {
        foreach (Wrappable item in wrappables)
        {
            Vector2 pos = _camera.WorldToViewportPoint(item.transform.position);
            Vector2 newPosition = item.transform.position;

            if (pos.x > 1.02f)
            {
                newPosition.x = -newPosition.x + .2f;
            }
            else if (pos.x < -0.02f)
            {
                newPosition.x = -newPosition.x - .2f;
            }
            
            if (pos.y > 1.02f)
            {
                newPosition.y = -newPosition.y + .2f;
            } 
            else if (pos.y < -0.02f)
            {
                newPosition.y = -newPosition.y - .2f;
            }

            item.transform.position = newPosition;
        }
    }
}
