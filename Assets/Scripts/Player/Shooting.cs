using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject _bullet;
    public FixedJoystick _fj;
    private float _shootTimer, _shootDelay;

    public float ShootDelay
    {
        get
        {
            return _shootDelay;
        }

        set
        {
            _shootDelay = value;
        }
    }

    void Start () {
        _shootTimer = 0f;
        _shootDelay = 0.4f;
	}
	
	void Update () {
        _shootTimer += Time.deltaTime;

        if (_fj.IsShooting && _shootTimer > _shootDelay)
        {
            GameObject _tempBullet = Instantiate(_bullet, this.transform.position, this.transform.rotation);
            _tempBullet.GetComponent<Rigidbody2D>().gravityScale = 0f;
            _tempBullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * 1000f);
            Destroy(_tempBullet, 5f);
            _shootTimer = 0f;
        }
	}
}
