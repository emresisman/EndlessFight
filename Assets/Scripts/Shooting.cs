using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject _bullet;
    public FixedJoystick _fj;
    private float _shootDelay;

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
        _shootDelay = 0f;
	}
	
	void Update () {
        ShootDelay += Time.deltaTime;

        if (_fj.IsShooting && ShootDelay > 0.4f)
        {
            GameObject _tempBullet = Instantiate(_bullet, this.transform.position, this.transform.rotation);
            _tempBullet.GetComponent<Rigidbody2D>().gravityScale = 0f;
            _tempBullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * 1000f);
            Destroy(_tempBullet, 5f);
            ShootDelay = 0f;
        }
	}
}
