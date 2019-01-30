using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characon;
    private Animator _animator;

    [SerializeField] private float _speed = 0.1f;

    private Vector3 _first_mouse_position;
    private Vector3 _spinMousePosition;
    private bool _isClick = false;

    [SerializeField] private GameObject _attack;
    private Vector3 _spin_save_position;

    [SerializeField] private Vector3 gravity_d;
    private Vector3 gravity;

    /// <summary>
    /// 持っている武器
    /// </summary>
    [SerializeField] private Weapon _weapon;

    private void Awake()
    {
        _characon = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _first_mouse_position = Input.mousePosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Control();
        Spin();
        Attack();
        GravtiyAndJump();
    }

    private void Spin()
    {
        ////クリックでぐりぐり動かす
        //if (Input.GetMouseButtonDown(0))
        //{
        //    _spinMousePosition = Input.mousePosition;
        //    _isClick = true;
        //}

        //if (Input.GetMouseButton(0))
        //{
        //    if (_isClick)
        //    {
        //        Vector3 spin = _spin_save_position;
        //        spin.y = _spin_save_position.y +Input.mousePosition.x - _spinMousePosition.x;
        //        transform.eulerAngles = spin;
        //    }
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    _isClick = false;
        //    _spin_save_position = transform.eulerAngles;
        //}

        //クリックしないで視点回転
                Vector3 spin = transform.eulerAngles;
                spin.y = Input.mousePosition.x -_first_mouse_position.x;
                transform.eulerAngles = spin;

    }

    private void Control()
    {
        //歩く
        if (Input.GetKey(KeyCode.W))
        {
            _characon.Move(transform.forward*_speed);
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            {
                _animator.SetBool("walk",true);
            }
        }
        else
        //止まる
        {
            _animator.SetBool("walk", false);
        }
    }

    private void Attack()
    {
        if (false)
        {

        }
        else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("smallattack", true);
            _attack.SetActive(true);
            Invoke("AfterAttack", 0.5f);
            _weapon.HandOn();
        }
    }

    private void AfterAttack()
    {
        _animator.SetBool("smallattack", false);
        _attack.SetActive(false);
    }

    private void GravtiyAndJump()
    {
        if (!_characon.isGrounded)
        {
            _characon.Move(gravity);
            gravity += gravity_d;
        }
        else
        {
            gravity = new Vector3(0,0,0);
            if (Input.GetKey(KeyCode.S))
            {
                StartCoroutine("Jump");
            }
        }
    }

    IEnumerator Jump()
    {
        float jumpPower = 0.6f;
        for (int i = 0; i < 10; i++)
        {
            _characon.Move(new Vector3(0, jumpPower, 0));
            jumpPower *= 0.9f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
