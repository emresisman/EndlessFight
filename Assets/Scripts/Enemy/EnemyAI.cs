using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    private CameraController _cC;
    private PlayerMovement _target;
    private Score _score;
    public float _enemySpeed;
    public int _health;
    public int _value;
    public int _damage;
    public GameObject _deathExplosion;

	void Start () {
        _cC = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        _score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
    }
	
	void Update () {
        Vector3 _moveVector = _target.GetPosition() - transform.position;
        _moveVector = _moveVector.normalized;
        this.transform.Translate(_moveVector * Time.deltaTime * _enemySpeed, Space.World);
    }
    
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            _cC.Shake();
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            _health -= SaveReader.damage;
            if (_health <= 0)
            {
                Destroy(this.gameObject);
                _score.EnemyDead(10);
            }
        }
    }*/
     
    void DeathWithBullet()
    {
        Destroy(this.gameObject);
        _score.EnemyDead(_value);
    }

    void DeathWithPlayer()
    {
        Destroy(this.gameObject);
        _cC.Shake();
        _target.TakeDamage(_damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DeathWithPlayer();
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            _health -= SaveReader.damage;
            if (_health <= 0)
            {
                DeathWithBullet();
            }
        }
    }
}
