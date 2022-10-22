using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ResultSystem : MonoBehaviour
{
    [SerializeField] FadeSystem _fadeSystem;
    [SerializeField] string _titleSceneName = "Title";
    [SerializeField] float _resultTime = 2;
    float _timer = 0;

    private void Update()
    {       
        _timer += Time.deltaTime;

        if (Input.anyKeyDown && _timer > _resultTime)
        {
            _fadeSystem.StartFadeOut(_titleSceneName);
        }
    }
}
