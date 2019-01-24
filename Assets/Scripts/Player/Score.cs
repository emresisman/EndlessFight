using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float _score = 0f, _comboTimer = 2f;
    private int _comboCount = 1;
    private int _money = 0;
    //public SaveManager save;

    void Update()
    {
        if (_comboTimer <= 0)
        {  
            _comboCount = 0;
            _comboTimer = 0;
        }
        //save.Save((int)_score);
        _comboTimer -= Time.deltaTime;
        UIText.ScoreText(_score);
        UIText.ComboText(_comboCount);
    }

    public void EnemyDead(int _enemyClass)
    {
        _score += _enemyClass *_comboCount;
        _comboCount++;
        _comboTimer = 2f;
        _money += 10;
    }

    public int GetScore()
    {
        return (int)_score;
    }

    public int GetMoney()
    {
        return _money;
    }
}
