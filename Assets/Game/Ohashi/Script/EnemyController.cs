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
    [Tooltip("�����̔z��̃C���f�b�N�X")]int _count = 0;

    void Start()
    {
        _nav = GetComponent<NavMeshAgent2D>();
        _fade = FindObjectOfType<FadeSystem>().GetComponent<FadeSystem>();
        _playerMove = FindObjectOfType<MovementController>().GetComponent<MovementController>();
    }

    void Update()
    {
        //����̃��[�v
        if (_targets.Length <= _count)
        {
            _count = 0;
        }
        if (!SkillSystem._isLight)
        {
            //�v���C���[���e�ɂ��Ȃ��Ƃ�
            if (_playerMove.Shadow || isSuccess)
            {
                //�v���C���[��ǂ�������
                _nav.destination = _paler.position;
            }
            //�v���C���[���e�ɂ���Ƃ�
            else
            {
                //���񂳂���
                _nav.destination = _targets[_count].position;
            }
        }
        //���C�g���S���������Ƃ�
        else
        {
            //�����Ȃ�
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
            //������ς���
            _count += 1;
        }
    }
}
