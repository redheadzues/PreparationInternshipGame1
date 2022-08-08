using UnityEngine;
using UnityEngine.Events;

public class Circle : MonoBehaviour
{
    private int _score;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> Died;

    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        Died?.Invoke(_score);
    }

    public void ResetParametrs()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        transform.position = _startPosition;
    }
}
