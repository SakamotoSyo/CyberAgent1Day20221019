using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yasuda;

public class EnemyController : MonoBehaviour
{
    
    [SerializeField] Transform _paler;
    NavMeshAgent2D _nav;
    FadeSystem _fade;
    void Start()
    {
        _nav = GetComponent<NavMeshAgent2D>();
        _fade = GetComponent<FadeSystem>();
    }

    void Update()
    {
        //ライトがついてるときは以下を実行する
        if (SkillSystem._isLight)
        {
            _nav.destination = _paler.position;//プレイヤーを追跡する
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーに接触したとき以下を実行する
        if(collision.gameObject.tag == "Player")
        {
            _fade.StartFadeOut("リザルトscene名を後で入力しとく");
        }
    }
}
