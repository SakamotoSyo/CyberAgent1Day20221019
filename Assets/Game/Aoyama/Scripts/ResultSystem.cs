using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSystem : MonoBehaviour
{
    [SerializeField] FadeSystem _fadeSystem;
    [SerializeField] string _titleSceneName = "Title";

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _fadeSystem.StartFadeOut(_titleSceneName);
        }
    }
}
