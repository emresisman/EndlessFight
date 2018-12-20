using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    private GameObject _joystick, _handle;
    private FixedJoystick _fj;
    float _angle, _temp;

    void Start()
    {
        _joystick = GameObject.Find("Direction");
        _handle = GameObject.Find("Direction").transform.GetChild(0).gameObject;
        _fj = _joystick.GetComponent<FixedJoystick>();
    }

    void Update () {
        //Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(this.transform.position);
        //Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 positionOnScreen = _joystick.transform.position;
        Vector2 mouseOnScreen = _handle.transform.position;
        _angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        if (_fj.IsShooting)
        {
            _temp = _angle;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, _angle - 90f));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, _temp - 90f));
        }

    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
