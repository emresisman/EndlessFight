using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    private GameObject _joystick, _handle;

    void Start()
    {
        _joystick = GameObject.Find("Direction");
        _handle = GameObject.Find("Direction").transform.GetChild(0).gameObject;
    }

    void Update () {
        //Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(this.transform.position);
        //Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 positionOnScreen = _joystick.transform.position;
        Vector2 mouseOnScreen = _handle.transform.position;
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
