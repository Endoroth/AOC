using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour
{

    public Sprite[] Korvar;
    public Image KorvHP;

    private Player _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        KorvHP.sprite = Korvar[_player.CurrentHealth];
    }
}