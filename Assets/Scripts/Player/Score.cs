using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using emresisman;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float _score = 0f, _comboTimer = 2f;
    private int _comboCount = 1;
    private int _money = 0;
    private int _deathCount = 0;

    public int DeathCount
    {
        get
        {
            return _deathCount;
        }

        set
        {
            _deathCount = value;
        }
    }

    //public SaveManager save;

    void Update()
    {
        UIWriter.SkorYaz(_score, NesneBul.TextBul("ScoreText"));
        UIWriter.KomboYaz(_comboCount, NesneBul.TextBul("ComboText"));
        if (_comboTimer <= 0)
        {  
            _comboCount = 1;
            _comboTimer = 0;
        }
        //save.Save((int)_score);
        _comboTimer -= Time.deltaTime;
        
        //UIText.ScoreText(_score);
        //UIText.ComboText(_comboCount);
    }

    public void EnemyDead(int _enemyClass)
    {
        _score += _enemyClass *_comboCount;
        _comboCount++;
        _comboTimer = 2f;
        _money += 10;
        _deathCount += 1;
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
