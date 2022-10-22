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
        //���C�g�����Ă�Ƃ��͈ȉ������s����
        if (SkillSystem._isLight)
        {
            _nav.destination = _paler.position;//�v���C���[��ǐՂ���
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[�ɐڐG�����Ƃ��ȉ������s����
        if(collision.gameObject.tag == "Player")
        {
            _fade.StartFadeOut("���U���gscene������œ��͂��Ƃ�");
        }
    }
}
