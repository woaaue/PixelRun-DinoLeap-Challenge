using UnityEngine;
using System.Collections.Generic;

public sealed class PoolObject<T> where T : MonoBehaviour
{
    private T _prefab;
    private int _count;
    private List<T> _pool;
    private Transform _transform;

    public PoolObject(T prefab, int count, Transform transform)
    {
        _prefab = prefab;
        _count = count;
        _transform = transform;

        CreatePool(_count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveDefault = false)
    {
        var createdObject = Object.Instantiate(_prefab, _transform);
        createdObject.gameObject.SetActive(isActiveDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    private bool HasFreeElement(out T element)
    {
        foreach (var mono in _pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out T element))
        {
            return element;
        }

        return CreateObject(true);
    }
}
