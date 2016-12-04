using UnityEngine;
using System.Collections;
using System;

public class Barrel : MonoBehaviour
{
    int MaxHP = 100;
    int HP;

	// Use this for initialization
	void Start ()
    {
        HP = MaxHP;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("dmg"))
        {
            var dmg = Int32.Parse(collision.tag.Substring(3));
            HP = HP - dmg;
        }
    }
    private void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
