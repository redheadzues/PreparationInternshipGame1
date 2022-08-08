using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _capacity;

    private Camera _camera;
    private List<GameObject> _prefabs = new List<GameObject>();

    private void Update()
    {
        DeactivePrefabsBehindScreen();
    }

    protected void Initialize()
    {
        _camera = Camera.main;

        for(int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(_prefab, _container.transform);
            spawned.SetActive(false);
            _prefabs.Add(spawned);
        }

    }

    protected bool TryGetObject(out GameObject prefab)
    {
        prefab = _prefabs.FirstOrDefault(prefab => prefab.activeSelf == false);

        return prefab != null;
    }

    protected void DeactivePrefabsBehindScreen()
    {
        Vector2 disablePoint = _camera.ViewportToWorldPoint(Vector2.zero);

        foreach (GameObject prefab in _prefabs)
        {
            if ((prefab.activeSelf == true))
                if ((prefab.transform.position.x < disablePoint.x))
                    prefab.SetActive(false);
        }
    }

    public void ResetPool()
    {
        foreach (var prefab in _prefabs)
        {
            prefab.SetActive(false);
        }
    }
}
