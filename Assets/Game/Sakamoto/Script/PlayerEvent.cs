using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class PlayerEvent : MonoBehaviour
{
    [Header("sin")]
    [SerializeField] GameObject _playOver;
    PlayableDirector _timeline;
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            Instantiate(_playOver, gameObject.transform);
            gameObject.SetActive(false);
        } 
    }
}
