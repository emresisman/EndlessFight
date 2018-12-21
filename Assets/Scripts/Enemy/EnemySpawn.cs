using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    private float _instantiateDelay, _instantiateTimer, _yMin, _yMax, _xMin, _xMax, _ySpace, _xSpace;
    private Vector3 _randomPoint;
    private PlayerMovement _player;
    public GameObject _enemy;

	void Start () {
        _yMin = -27f;
        _yMax = 27f;
        _xMin = -50f;
        _xMax = 50f;
        _ySpace = 7f;
        _xSpace = 13f;
        _instantiateTimer = 0f;
        _instantiateDelay = 1f;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}
	
	void Update () {
        _instantiateTimer += Time.deltaTime;
        if (_instantiateTimer > _instantiateDelay)
        {
            CreateEnemy();
            _instantiateTimer = 0f;
        }
	}

    private void CreateEnemy()
    {
        Vector3 _playerPosition = _player.GetPosition();
        GameObject _enemyTemp = Instantiate(_enemy, new Vector3(RandomX(_playerPosition, _xSpace), RandomY(_playerPosition, _ySpace), -0.01f), this.transform.rotation);
    }

    private float RandomX(Vector3 _playerPos, float _space)
    {
        float _randomPos;
        while (true)
        {
            _randomPos = Random.Range(-50f, 50f);
            if (_randomPos > _playerPos.x + _space || _randomPos < _playerPos.x - _space)
            {
                break;
            }
        }
        return _randomPos;
    }

    private float RandomY(Vector3 _playerPos, float _space)
    {
        float _randomPos;
        while (true)
        {
            _randomPos = Random.Range(-27f, 27f);
            if (_randomPos > _playerPos.y + _space || _randomPos < _playerPos.y - _space)
            {
                break;
            }
        }
        return _randomPos;
    }
}
