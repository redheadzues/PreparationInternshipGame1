using System.Collections;
using UnityEngine;

public class Generator : ObjectsPool
{
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxVerticalPosition;
    [SerializeField] private float _minVerticalPosition;

    private float _verticalPosition;

    private void Start()
    {
        StartCoroutine(PlacePrefab());
        Initialize();
    }

    private void ChooseVerticalPosition()
    {
        _verticalPosition = Random.Range(_minVerticalPosition, _maxVerticalPosition);
    }

    private IEnumerator PlacePrefab()
    {
        var waitingTime = new WaitForSeconds(_secondsBetweenSpawn);

        while(true)
        {
            if(TryGetObject(out GameObject prefab))
            {
                prefab.SetActive(true);
                ChooseVerticalPosition();
                prefab.transform.position = new Vector2(transform.position.x, _verticalPosition);
            }

            yield return waitingTime;
        }
    }
}
