using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characon;
    private Animator _animator;

    [SerializeField] private float _speed = 0.1f;

    private Vector3 _spinMousePosition;
    private bool _isClick = false;

    [SerializeField] private GameObject _attack;
    private Vector3 _spin_save_position;

    private void Awake()
    {
        _characon = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
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
    }

    private void Spin()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _spinMousePosition = Input.mousePosition;
            _isClick = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (_isClick)
            {
                Vector3 spin = _spin_save_position;
                spin.y = Input.mousePosition.x - _spinMousePosition.x;
                transform.eulerAngles = spin;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isClick = false;
            _spin_save_position = transform.eulerAngles;
        }
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
        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("smallattack", true);
            _attack.SetActive(true);
            Invoke("AfterAttack", 0.5f);
        }
    }

    private void AfterAttack()
    {
        _animator.SetBool("smallattack", false);
        _attack.SetActive(false);
    }
}
