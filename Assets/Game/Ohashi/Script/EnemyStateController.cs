using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    EnemyController _enemy;
    public EnemyState _state = EnemyState.normal;
    public enum EnemyState
    {
        normal,
        stop,
        attack,

    }
    void Start()
    {
        _enemy = GetComponent<EnemyController>();
    }

    void Update()
    {

    }
}
