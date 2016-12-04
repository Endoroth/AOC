using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour
{
    public GameObject poof;
    private void Start()
    {
        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "destructible")
        {
            var _poof = Instantiate(poof, transform.position, transform.rotation) as GameObject;
            //Destroy(collision.gameObject);

        }
        if (collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}





