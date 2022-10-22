using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("GameOverScene‚Ì–¼‘O")]
    [SerializeField] string _gameOverScenePath;

    float _time = 0;
    float _timelineTime;
    FadeSystem _fade;
    // Start is called before the first frame update
    void Start()
    {
        _timelineTime = 3f;
        _fade = GameObject.Find("GameManager").GetComponent<FadeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if(_time > _timelineTime) 
        {
            _fade.StartFadeOut(_gameOverScenePath);
        }
    }
}
