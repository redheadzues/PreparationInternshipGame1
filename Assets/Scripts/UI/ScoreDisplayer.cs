using TMPro;
using UnityEngine;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private Circle _circle;
    [SerializeField] private TMP_Text _scoreDisplay;

    private string _baseText;

    private void Start()
    {
        _baseText = _scoreDisplay.text;   
    }

    private void OnEnable()
    {
        _circle.ScoreChanged += OnScoreIncrease;
    }

    private void OnDisable()
    {
        _circle.ScoreChanged -= OnScoreIncrease;
    }

    private void OnScoreIncrease(int score)
    {
        _scoreDisplay.text = _baseText + score.ToString();
    }
}
