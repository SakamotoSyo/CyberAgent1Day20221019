using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

public class ResultSystem : MonoBehaviour
{
    [SerializeField] FadeSystem _fadeSystem;

    public void ReStart()
    {
        _fadeSystem.StartFadeOut(TitleSystem._sceneName);
    }
}
