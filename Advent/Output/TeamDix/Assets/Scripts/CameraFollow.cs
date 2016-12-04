using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    private Vector2 _velocity;

    public float SmoothTimeX;
    public float SmoothTimeY;

    public GameObject Player;

    public bool RestrictCamera;

    public Vector3 MinCameraPos;
    public Vector3 MaxCameraPos;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        var posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref _velocity.x, SmoothTimeX);
        var posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref _velocity.y, SmoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (RestrictCamera)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinCameraPos.x, MaxCameraPos.x),
                                             Mathf.Clamp(transform.position.y, MinCameraPos.y, MaxCameraPos.y),
                                             Mathf.Clamp(transform.position.z, MinCameraPos.z, MaxCameraPos.z));
        }
    }

    public void SetMinCamPosition()
    {
        MinCameraPos = gameObject.transform.position;
    }

    public void SetMaxCamPosition()
    {
        MaxCameraPos = gameObject.transform.position;
    }
}