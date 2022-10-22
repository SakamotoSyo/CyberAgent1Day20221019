using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerInput : MonoBehaviour
{
    [Header("?X?L????N?[???^?C??")]
    [SerializeField] float _actionWait;
    [Header("?X?L??Script")]
    [SerializeField] SkillSystem _skillSystem;
    [Header("Animator")]
    [SerializeField] Animator _anim;
    [Header("Player??Sprite")]
    [SerializeField] SpriteRenderer _playerSprite;

    [Tooltip("Skill??Sprite")]
    Image _skillSprite;
    [Tooltip("????????")]
    Vector2 _movement;
    [Tooltip("????????????????????????")]
    Vector2 _playerDirection;
    [Tooltip("????Skill???g????")]
    bool _isSkill = true;
    [Tooltip("Input???u???b?N?????????")]
    bool _inputBlock = false;

    Coroutine _actionCoroutine;
    WaitForSeconds _actionWaitForSeconds;

    void Awake()
    {
        _actionWaitForSeconds = new WaitForSeconds(_actionWait);
        // _skillSprite = GameObject.Find("SkillGaugePrefab/SkillGauge").GetComponent<Image>();
        if (_skillSprite == null)
        {
            Debug.LogError("SkillSprite??Null???");
        }
    }

    /// <summary>????X?L?????g????????????</summary>
    public bool Skill
    {
        get { return _isSkill && !_inputBlock; }
    }
    /// <summary>???????????????</summary>
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
            //Player???????]??????
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
    /// ????X?L?????g???????N?[???^?C??
    /// </summary>
    /// <returns></returns>
    IEnumerator ActionWait()
    {
        _isSkill = false;
        Debug.Log("?X?L???J?n");
        _anim.SetTrigger("Skill");

        //?X?L????N?[???^?C???????????I????\??????
        DOTween.To(() => 0f,
            x => _skillSprite.fillAmount = x,
            1f, _actionWait);

        _skillSystem.LightOff(_actionWait);
        yield return _actionWaitForSeconds;

        Debug.Log("?X?L???I??");
        _isSkill = true;
    }

    /// <summary>Input????????????t???????????X????</summary>
    public void InputBlock()
    {
        Debug.Log("????");
        _inputBlock = !_inputBlock;
    }
}
