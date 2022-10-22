using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationCon : MonoBehaviour
{
    [Header("PlayerInput")]
    [SerializeField] PlayerInput _playerInput;

    [Header("Animator")]
    [SerializeField] Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //WalkAnimation
        _anim.SetBool("Walk", _playerInput.MoveInput.x != 0 || _playerInput.MoveInput.y != 0);
        //false‚É‚È‚Á‚½‚çAnimationŠJŽn
        //_anim.SetBool("Skill", !_playerInput.Skill);
    }
}
