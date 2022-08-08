using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameRestarter : MonoBehaviour
{
    [SerializeField] private Circle _circle;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private TMP_Text _finalScore;
    [SerializeField] private List<ObjectsPool> _objectsPool;

    private int _stopGame = 0;
    private int _startGame = 1;
    private string _baseText;

    private void Start()
    {
        _baseText = _finalScore.text;   
    }

    private void OnEnable()
    {
        _circle.Died += OnCircleDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _circle.Died -= OnCircleDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnRestartButtonClick()
    {
        _gameOverPanel.SetActive(false);
        ResetObjectsPool();
        _circle.ResetParametrs();
        Time.timeScale = _startGame;
    }

    private void OnCircleDied(int finalScore)
    {
        Time.timeScale = _stopGame;
        _gameOverPanel.SetActive(true);
        _finalScore.text = _baseText + finalScore.ToString();
    }

    private void ResetObjectsPool()
    {
        for(int i = 0; i < _objectsPool.Count; i++)
        {
            _objectsPool[i].ResetPool();
        }
    }
}
