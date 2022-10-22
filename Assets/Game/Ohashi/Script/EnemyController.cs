using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yasuda;

public class EnemyController : MonoBehaviour
{
    
    [SerializeField] Transform _paler;
    [SerializeField] Transform[] _targets;
    [SerializeField] bool isSuccess = false;
    NavMeshAgent2D _nav;
    FadeSystem _fade;
    MovementController _playerMove;
    [Tooltip("巡回先の配列のインデックス")]int _count = 0;

    void Start()
    {
        _nav = GetComponent<NavMeshAgent2D>();
        _fade = FindObjectOfType<FadeSystem>().GetComponent<FadeSystem>();
        _playerMove = FindObjectOfType<MovementController>().GetComponent<MovementController>();
    }

    void Update()
    {
        //巡回のループ
        if (_targets.Length <= _count)
        {
            _count = 0;
        }
        if (!SkillSystem._isLight)
        {
            //プレイヤーが影にいないとき
            if (_playerMove.Shadow || isSuccess)
            {
                //プレイヤーを追いかける
                _nav.destination = _paler.position;
            }
            //プレイヤーが影にいるとき
            else
            {
                //巡回させる
                _nav.destination = _targets[_count].position;
            }
        }
        //ライトが全部消えたとき
        else
        {
            //動かない
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _fade.StartFadeOut("Failed");
        }
        if (collision.gameObject.tag == "Target")
        {
            //巡回先を変える
            _count += 1;
        }
    }
}
