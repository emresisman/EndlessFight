using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject _bullet;
    public FixedJoystick _fj;
    private float _shootTimer;

    void Start () {
        _shootTimer = 0f;
	}
	
	void Update () {
        _shootTimer += Time.deltaTime;

        if (_fj.IsShooting && _shootTimer > SaveReader.fireRate)
        {
            GameObject _tempBullet = Instantiate(_bullet, this.transform.position, this.transform.rotation);
            _tempBullet.GetComponent<Rigidbody2D>().gravityScale = 0f;
            _tempBullet.GetComponent<Rigidbody2D>().AddForce(-transform.up * SaveReader.bulletSpeed);
            Destroy(_tempBullet, 5f);
            _shootTimer = 0f;
        }
	}
}
