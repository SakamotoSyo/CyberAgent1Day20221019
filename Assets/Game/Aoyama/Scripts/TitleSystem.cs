using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class TitleSystem : MonoBehaviour
{
    [SerializeField] FadeSystem _fadeSystem;
    [SerializeField] EventSystem _eventSystem;
    [SerializeField] GameObject _helpButton;
    [SerializeField] GameObject[] _startObjects;
    [SerializeField] GameObject[] _noStartObjects;

    void Awake()
    {
        _fadeSystem.StartFadeIn();
        _startObjects.ToList().ForEach(o => o.SetActive(true));
        _noStartObjects.ToList().ForEach(o => o.SetActive(false));

        
    }

    private void FixedUpdate()
    {
        if (_eventSystem.currentSelectedGameObject)
        {
            if (!_eventSystem.currentSelectedGameObject.activeSelf)
            {
                _eventSystem.SetSelectedGameObject(_helpButton);
            }
        }
    }
}
