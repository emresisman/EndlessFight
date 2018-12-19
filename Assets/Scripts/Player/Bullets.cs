using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    private SpriteRenderer _sprites;

	void Start () {
        _sprites = this.GetComponent<SpriteRenderer>();
        _sprites.sprite=Resources.Load("Sprites/Player/Bullets/Bullet1", typeof(Sprite)) as Sprite;
    }
	
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "DangerZone")
        {
            Destroy(this.gameObject);
        }
    }
}
