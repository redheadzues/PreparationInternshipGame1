using UnityEngine;

public class CoinActivator : MonoBehaviour
{
    private GameObject[] _coins;

    private void Awake()
    {
        _coins = new GameObject[transform.childCount];

        for(int i = 0; i < _coins.Length; i++)
        {
            _coins[i] = transform.GetChild(i).gameObject;
        }
    }

    private void OnEnable()
    {
        for(int i = 0; i < _coins.Length; i++)
        {
            _coins[i].SetActive(true);
        }
    }
}
