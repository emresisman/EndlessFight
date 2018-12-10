using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float _horizontalSpeed, _verticalSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _horizontalSpeed = Mathf.Clamp(Input.GetAxis("Horizontal"), -0.2f, 0.2f);
        _verticalSpeed = Mathf.Clamp(Input.GetAxis("Vertical"), -0.2f, 0.2f);
        //Debug.Log(-_horizontalSpeed + " " + _verticalSpeed);
        this.transform.Translate(_horizontalSpeed, _verticalSpeed, 0f);
	}
}
