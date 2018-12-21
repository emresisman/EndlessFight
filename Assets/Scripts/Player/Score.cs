using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float _score = 0f, _comboTimer = 2f;
    private int _comboCount = 0;

    void Update()
    {
        if (_comboTimer <= 0)
        {
            _comboCount = 0;
            _comboTimer = 0;
        }
        _comboTimer -= Time.deltaTime;
        _score += Time.deltaTime * 10f;
        UIText.ScoreText(_score);
        UIText.ComboText(_comboCount);
    }

    public void EnemyDead(int _enemyClass)
    {
        _score += _enemyClass *_comboCount;
        _comboCount++;
        _comboTimer = 2f;
    }

    public void PlayerDamage()
    {
        _score -= 10;
        _comboCount = 0;
        _comboTimer = 0f;
    }
}
