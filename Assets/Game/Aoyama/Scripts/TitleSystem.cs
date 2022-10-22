using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TitleSystem : MonoBehaviour
{
    [SerializeField] FadeSystem _fadeSystem;
    [SerializeField] GameObject[] _startObjects;
    [SerializeField] GameObject[] _noStartObjects;

    void Awake()
    {
        _startObjects.ToList().ForEach(o => o.SetActive(true));
        _noStartObjects.ToList().ForEach(o => o.SetActive(false));
    }
}
