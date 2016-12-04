using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed = 60f;
    public float JumpPower = 7f;
    public float JumpEase = 0.99f;

    public float RestartPosY = -5f;

    public int CurrentHealth;
    public int MaxHealth = 5;

    public bool IsGrounded;
    public bool CanDoubleJump;  

    [HideInInspector]
    public bool IsDoubleJumpAvailable;

    private float _facing;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    public Text VelocityText;
    public AudioSource AudioS;
    public AudioClip[] Clips;

    // rangeAttack1 var
    public GameObject rangeAttack1;
    public Text rangeAttack1CDText;
    public float rangeAttack1Cooldown = 5f;
    float _nextfireRA1 = 0f;

    // rangeAttack2 var
    public GameObject rangeAttack2;
    public Text rangeAttack2CDText;
    public float rangeAttack2Cooldown = 5f;
    float _nextfireRA2 = 0f;

    bool _isAttacking;
    bool _isAttackingRa1;
    bool _isAttackingRa2;

    private void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
        _facing = 1f;
        rangeAttack1CDText.text = "";
        rangeAttack2CDText.text = "";

        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        _animator.SetBool("Grounded", IsGrounded);
        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody2D.velocity.x));

        _isAttacking = _isAttackingRa1 || _isAttackingRa2;
        _animator.SetBool("AttackStart", _isAttacking);

        var h = Input.GetAxis("Horizontal");

        if (h < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _facing = -1;

            if (!AudioS.isPlaying && IsGrounded)
            {
                AudioS.clip = Clips[2];
                AudioS.Play();
            }
        }

        if (h > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            _facing = 1f;

            if (!AudioS.isPlaying && IsGrounded)
            {
                AudioS.clip = Clips[2];
                AudioS.Play();
            }
        }

        if (Input.GetButtonDown("Jump") && (IsGrounded || IsDoubleJumpAvailable))
        {
            //_rigidbody2D.AddForce(Vector2.up * JumpPower);
            //_rigidbody2D.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);


            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, JumpPower);

            AudioS.clip = Clips[0];
            AudioS.Play();

            if (CanDoubleJump)
                if (!IsGrounded && IsDoubleJumpAvailable)
                    IsDoubleJumpAvailable = false;
        }

        if (transform.position.y < RestartPosY)
        {
            SceneManager.LoadScene("Main");
        }
        
        VelocityText.text = "v x:" + Mathf.Abs(_rigidbody2D.velocity.x) + "\nv y:" + Mathf.Abs(_rigidbody2D.velocity.y) + "\nh:" +h;
        VelocityText.transform.position = new Vector2(_rigidbody2D.position.x + 2f, _rigidbody2D.position.y);

         //rangeAttack1
        if (Input.GetButton("Fire1") && Time.time > _nextfireRA1 && !_isAttacking)
        {            
            _isAttackingRa1 = true;            
        }
        //rangeAttack2
        if (Input.GetButton("Fire2") && Time.time > _nextfireRA2 && !_isAttacking && !_isAttackingRa1)
        {
            _isAttackingRa2 = true;
        }
        //Calculate and show cooldown RA1
        var _calcCD_RA1 = _nextfireRA1 - Time.time;
        if(_calcCD_RA1 >= 0 && !_isAttackingRa1) 
        { 
            rangeAttack1CDText.text = _calcCD_RA1.ToString("####0.0");
        }
        else
        {
            rangeAttack1CDText.text = "";
        }
        //Calculate and show cooldown  RA2
        var _calcCD_RA2 = _nextfireRA2 - Time.time;
        if (_calcCD_RA2 >= 0 && !_isAttackingRa2)
        {
            rangeAttack2CDText.text = _calcCD_RA2.ToString("####0.0");
        }
        else
        {
            rangeAttack2CDText.text = "";
        }

        //HP
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");

        var easeVelocity = _rigidbody2D.velocity;
        easeVelocity.x *= JumpEase;

        //_rigidbody2D.AddForce((Vector2.right*Speed)*h);
        //if(IsGrounded)
        _rigidbody2D.velocity = new Vector2(h*Speed, _rigidbody2D.velocity.y);

        if (!IsGrounded)
            _rigidbody2D.velocity = easeVelocity;
    }

    public void Die()
    {
        SceneManager.LoadScene("Main");
    }


    public void attackAfterAnimation()
    {
        if (_isAttackingRa1)
        {
            _nextfireRA1 = Time.time + rangeAttack1Cooldown;
            rangeAttack(_facing, rangeAttack1, 10f);
            _isAttackingRa1 = false;
        }
        if (_isAttackingRa2)
        {
            _nextfireRA2 = Time.time + rangeAttack2Cooldown;
            rangeAttack(_facing, rangeAttack2, 8f);
            _isAttackingRa2 = false;
        }
    }
    //rangeAttack Attack
    public void rangeAttack(float faceDirection, GameObject attackObject, float attackSpeed )
    {
        Vector2 direction = _rigidbody2D.transform.position + new Vector3(faceDirection * 100 , 0 ,0);
        direction.Normalize();

        var rangeAttackClone = Instantiate(attackObject, transform.position, transform.rotation) as GameObject;

        if (rangeAttackClone != null)
            rangeAttackClone.GetComponent<Rigidbody2D>().velocity = direction * attackSpeed;
    }
}