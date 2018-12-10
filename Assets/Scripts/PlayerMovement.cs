using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float _horizontalSpeed, _verticalSpeed;

	// Update is called once per frame
	void Update () {
        _horizontalSpeed = Mathf.Clamp(Input.GetAxis("Horizontal"), -0.05f, 0.05f);
        _verticalSpeed = Mathf.Clamp(Input.GetAxis("Vertical"), -0.05f, 0.05f);
        this.transform.Translate(-_horizontalSpeed, -_verticalSpeed, 0f);
	}
}
