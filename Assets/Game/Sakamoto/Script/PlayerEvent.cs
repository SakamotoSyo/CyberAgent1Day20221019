using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class PlayerEvent : MonoBehaviour
{
    [Header("€‚ñ‚¾‚Æ‚«‚Ì‰‰o‚ğ‚³‚¹‚éPrefab")]
    [SerializeField] GameObject _playOver;
    PlayableDirector _timeline;

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
           GameObject obj = Instantiate(_playOver, transform.position, transform.rotation);
           gameObject.SetActive(false);
        } 
    }
}
