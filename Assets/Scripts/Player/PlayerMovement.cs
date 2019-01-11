using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private int health;
    float _horizontalSpeed, _verticalSpeed;
    public FixedJoystick _joystick;

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    void Update () {
        //_horizontalSpeed = Mathf.Clamp(Input.GetAxis("Horizontal"), -0.05f, 0.05f);
        //_horizontalSpeed = Mathf.Clamp(_joystick.Horizontal, -0.05f, 0.05f);
        //_verticalSpeed = Mathf.Clamp(Input.GetAxis("Vertical"), -0.05f, 0.05f);
        //_verticalSpeed = Mathf.Clamp(_joystick.Vertical, -0.05f, 0.05f);
        //this.transform.Translate(-_horizontalSpeed, -_verticalSpeed, 0f);
        //this.transform.position += new Vector3(_horizontalSpeed, _verticalSpeed, 0f);

        Vector3 moveVector = (Vector3.right * _joystick.Horizontal + Vector3.up * _joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            transform.Translate(moveVector * SaveReader.speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DangerZone")
        {
            UIText.DangerText(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "DangerZone")
        {
            UIText.DangerText(false);
        }
    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Score s = this.gameObject.GetComponent<Score>();
            SaveHelper.StopGame(s.GetScore());
        }
    }
}

