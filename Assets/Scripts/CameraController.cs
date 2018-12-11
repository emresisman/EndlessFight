using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private float _dampTime;
    private Vector3 _velocity;
    private Transform _target;
    private Camera _cam;

    void Start () {
        _dampTime = 0.15f;
        _velocity = Vector3.zero;
        _cam = this.gameObject.GetComponent<Camera>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	void Update () {
        if (_target)
        {
            Vector3 point = _cam.WorldToViewportPoint(_target.position);
            Vector3 delta = _target.position - _cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref _velocity, _dampTime);
        }
    }
}
