using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private float _dampTime;
    private Vector3 _velocity, _tempPos;
    private Transform _target;
    private Camera _cam;
    private float _shakeDuration = 0f;
    private float _shakeAmount = 0.25f;

    void Start () {;
        _dampTime = 0.15f;
        _velocity = Vector3.zero;
        _tempPos = Vector3.zero;
        _cam = this.gameObject.GetComponent<Camera>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	void Update ()
    {
        if (_target)
        {
            Vector3 point = _cam.WorldToViewportPoint(_target.position);
            Vector3 delta = _target.position - _cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref _velocity, _dampTime);
        }

        if (this.transform.position.x < -41f)
        {
            _tempPos = new Vector3(-41f, this.transform.position.y, this.transform.position.z);
            transform.position = _tempPos;
        }
        else if (this.transform.position.x > 41f)
        {
            _tempPos = new Vector3(41f, this.transform.position.y, this.transform.position.z);
            transform.position = _tempPos;
        }
        if (this.transform.position.y < -25f)
        {
            _tempPos = new Vector3(this.transform.position.x, -25f, this.transform.position.z);
            transform.position = _tempPos;
        }
        else if (this.transform.position.y > 25f)
        {
            _tempPos = new Vector3(this.transform.position.x, 25f, this.transform.position.z);
            transform.position = _tempPos;
        }

        if (_shakeDuration > 0)
        {
            transform.localPosition = transform.localPosition + Random.insideUnitSphere * _shakeAmount;

            _shakeDuration -= Time.deltaTime;
        }
        else
        {
            _shakeDuration = 0f;
        }
    }

    public void Shake()
    {
        _shakeDuration = 0.4f;
    }
}
