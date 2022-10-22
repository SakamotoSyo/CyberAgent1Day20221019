using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    [Header("�X�L���̃N�[���^�C��")]
    [SerializeField] float _actionWait;
    [Header("�X�L��Script")]
    [SerializeField] SkillSystem _skillSystem;
    [Header("Animator")]
    [SerializeField] Animator _anim;
    [Header("Sprite")]
    [SerializeField] SpriteRenderer _spriteRenderer;
    [Tooltip("��������")]
    Vector2 _movement;
    [Tooltip("�Ō�ɓ�����������ۑ����Ă���")]
    Vector2 _playerDirection;
    [Tooltip("����Skill���g���邩")]
    bool _isSkill = true;
    [Tooltip("Input���u���b�N���邩�ǂ���")]
    bool _inputBlock = false;

    Coroutine _actionCoroutine;
    WaitForSeconds _actionWaitForSeconds;

    void Awake()
    {
        _actionWaitForSeconds = new WaitForSeconds(_actionWait);
    }

    /// <summary>���݃X�L�����g���邩�ǂ����Ԃ�</summary>
    public bool Skill
    {
        get { return _isSkill && !_inputBlock; }
    }
    /// <summary>���݂̕������͂�Ԃ�</summary>
    public Vector2 MoveInput 
    {
        get 
        {
            if (_inputBlock) 
            {
                return Vector2.zero;
            }
            return _movement;
        }
    } 
    void Start()
    {
        
    }

    void Update()
    {
        _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (_movement.x != 0 || _movement.y != 0)
        {
            _anim.SetBool("Walk", true);
            _playerDirection = _movement;
            //Player�̌����𔽓]������
            if (_playerDirection.x < 0)
            {
                _spriteRenderer.flipX = false;
            }
            else if(_playerDirection.x > 0)
            {
                _spriteRenderer.flipX = true;
            }
        }
        else 
        {
            _anim.SetBool("Walk", false);
        }

        if (Input.GetButtonDown("Submit") && _isSkill) 
        {
            if (_actionCoroutine != null) 
            {
                StopCoroutine(_actionCoroutine);
            }

            _actionCoroutine = StartCoroutine(ActionWait());
        }
    }

    IEnumerator ActionWait() 
    {
        _isSkill = false;
        Debug.Log("�X�L���J�n");
        _anim.SetTrigger("Skill");

       // _skillSystem.LightOff(_actionWait);
        yield return _actionWaitForSeconds;

        Debug.Log("�X�L���I��");
        _isSkill = true;
    }

    /// <summary>Input�Ɋւ�����͂��󂯕t���邩�ǂ����ύX����</summary>
    public void InputBlock() 
    {
        Debug.Log("�Ă΂ꂽ");
        _inputBlock = !_inputBlock;
    }
}
