using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerInput : MonoBehaviour
{
    [Header("�X�L���̃N�[���^�C��")]
    [SerializeField] float _actionWait;
    [Header("�X�L��Script")]
    [SerializeField] SkillSystem _skillSystem;
    [Header("Animator")]
    [SerializeField] Animator _anim;
    [Header("Player��Sprite")]
    [SerializeField] SpriteRenderer _playerSprite;

    [Tooltip("Skill��Sprite")]
    Image _skillSprite;
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

    public Material mat1;
    public Material mat2;
    public FadeSystem fs;

    void Awake()
    {
        _actionWaitForSeconds = new WaitForSeconds(_actionWait);
        _skillSprite = GameObject.Find("SkillGaugePrefab/SkillGauge").GetComponent<Image>();
        if (_skillSprite == null)
        {
            Debug.LogError("SkillSprite��Null�ł�");
        }
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
    /// ���ɃX�L�����g���邽�߂̃N�[���^�C��
    /// </summary>
    /// <returns></returns>
    IEnumerator ActionWait()
    {
        _isSkill = false;
        Debug.Log("�X�L���J�n");
        _anim.SetTrigger("Skill");


        // マテリアル切り替え
        _playerSprite.material = mat2;

        // yield return _actionWaitForSeconds;
        //�X�L���̃N�[���^�C�����ǂꂭ�炢�ŏI��邩�\������

        yield return new WaitForSeconds(1.5f);


        DOTween.To(() => 0f,
            x => _skillSprite.fillAmount = x,
            1f, _actionWait);
        _skillSystem.LightOff(_actionWait);

        Debug.Log("�X�L���I��");
        _isSkill = true;

        yield return new WaitForSeconds(2f);

        // マテリアル切り替え
        _playerSprite.material = mat1;
    }

    /// <summary>Input�Ɋւ�����͂��󂯕t���邩�ǂ����ύX����</summary>
    public void InputBlock()
    {
        Debug.Log("�Ă΂ꂽ");
        _inputBlock = !_inputBlock;
    }

    private bool clearflg = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            
            collision.gameObject.transform.parent = this.gameObject.transform;
            clearflg = true;
            Debug.Log("アイテム");
        }
        if(collision.gameObject.tag == "Start")
        {
            if(clearflg){
                Debug.Log("クリア");
                fs.StartFadeOut("Success");
            }
        }
    }
}
