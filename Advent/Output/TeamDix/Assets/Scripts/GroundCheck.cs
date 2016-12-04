using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = gameObject.GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _player.IsGrounded = true;
        _player.AudioS.clip = _player.Clips[1];
        _player.AudioS.Play();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        _player.IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        _player.IsGrounded = false;
        _player.IsDoubleJumpAvailable = true;
    }
}