using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Box _box;

    private int _score = 0;
    public int Current => _score;

    private void ScoreChange(int value)
    {
        _score += value;
        _scoreText.text = ($"Score: {_score}");
    }

    private void OnEnable()
    {
        _box.Changed += ScoreChange;
    }

    private void OnDisable()
    {
        _box.Changed -= ScoreChange;
    }
}
