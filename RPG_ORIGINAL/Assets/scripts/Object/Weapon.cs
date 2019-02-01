using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /// <summary>
    /// 持たれていないときの場所
    /// </summary>
    [SerializeField] private Vector3 _originPosition;

    /// <summary>
    /// 持たれていないときの回転
    /// </summary>
    [SerializeField] private Vector3 _origineSpin;

    /// <summary>
    /// 持っているときの場所
    /// </summary>
    [SerializeField] private Vector3 _handedPosition;

    /// <summary>
    /// 持っているときの回転
    /// </summary>
    [SerializeField] private Vector3 _handedSpin;

    /// <summary>
    /// おさまっている親オブジェクト
    /// </summary>
    [SerializeField] private GameObject _origineParent;

    /// <summary>
    /// 武器を持つ手
    /// </summary>
    [SerializeField] private GameObject _hand;

    // Start is called before the first frame update
    void Start()
    {
        _origineParent = transform.parent.gameObject;
        _originPosition = transform.localPosition;
        _origineSpin = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandOn()
    {
        transform.parent = _hand.transform;
        transform.localPosition = _handedPosition;
        transform.localEulerAngles = _handedSpin;
    }

    public void HandOff()
    {
        transform.parent = _origineParent.transform;
        transform.localPosition = _originPosition;
        transform.localEulerAngles = _origineSpin;
    }
}
