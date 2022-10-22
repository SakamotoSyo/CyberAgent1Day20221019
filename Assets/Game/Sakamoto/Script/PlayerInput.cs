using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerInput : MonoBehaviour
{
    [Header("スキルのクールタイム")]
    [SerializeField] float _actionWait;
    [Header("スキルScript")]
    [SerializeField] SkillSystem _skillSystem;
    [Header("Animator")]
    [SerializeField] Animator _anim;
    [Header("PlayerのSprite")]
    [SerializeField] SpriteRenderer _playerSprite;

    [Tooltip("SkillのSprite")]
    Image _skillSprite;
    [Tooltip("動く方向")]
    Vector2 _movement;
    [Tooltip("最後に動いた方向を保存しておく")]
    Vector2 _playerDirection;
    [Tooltip("現在Skillが使えるか")]
    bool _isSkill = true;
    [Tooltip("Inputをブロックするかどうか")]
    bool _inputBlock = false;

    Coroutine _actionCoroutine;
    WaitForSeconds _actionWaitForSeconds;

    void Awake()
    {
        _actionWaitForSeconds = new WaitForSeconds(_actionWait);
        _skillSprite = GameObject.Find("SkillGaugePrefab/SkillGauge").GetComponent<Image>();
        if (_skillSprite == null)
        {
            Debug.LogError("SkillSpriteがNullです");
        }
    }

    /// <summary>現在スキルを使えるかどうか返す</summary>
    public bool Skill
    {
        get { return _isSkill && !_inputBlock; }
    }
    /// <summary>現在の方向入力を返す</summary>
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
            //Playerの向きを反転させる
            if (_playerDirection.x < 0)
            {
                _playerSprite.flipX = false;
            }
            else if (_playerDirection.x > 0)
            {
                _playerSprite.flipX = true;
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

    /// <summary>
    /// 次にスキルが使えるためのクールタイム
    /// </summary>
    /// <returns></returns>
    IEnumerator ActionWait()
    {
        _isSkill = false;
        Debug.Log("スキル開始");
        _anim.SetTrigger("Skill");

        //スキルのクールタイムがどれくらいで終わるか表示する
        DOTween.To(() => 0f,
            x => _skillSprite.fillAmount = x,
            1f, _actionWait);

        _skillSystem.LightOff(_actionWait);
        yield return _actionWaitForSeconds;

        Debug.Log("スキル終了");
        _isSkill = true;
    }

    /// <summary>Inputに関する入力を受け付けるかどうか変更する</summary>
    public void InputBlock()
    {
        Debug.Log("呼ばれた");
        _inputBlock = !_inputBlock;
    }
}
