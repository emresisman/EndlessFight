using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    private CameraController _cC;
    private PlayerMovement _target;
    private float _enemySpeed;

	void Start () {
        _enemySpeed = 0.1f;
        _cC = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}
	
	void Update () {
        Vector3 _moveVector = _target.GetPosition() - transform.position;
        _moveVector = _moveVector.normalized;
        this.transform.Translate(_moveVector * _enemySpeed, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            _cC.Shake();
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            _cC.Shake();
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }

    }
}
