using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class FadeSystem : MonoBehaviour
{
    [SerializeField, Tooltip("フェードに使うImage")] Image _fadeImage;
    [SerializeField, Tooltip("フェードにかける時間")] float _fadeTime = 3f;


    public void StartFadeIn()//フェードイン関数 
    {
        if (_fadeImage) _fadeImage.color = Color.black;
        _fadeImage.DOFade(endValue: 0f, duration: _fadeTime);
    }


    public void StartFadeOut(string scene)//フェードアウト関数
    {
        _fadeImage.gameObject.SetActive(true);
        _fadeImage.DOFade(endValue: 1f, duration: _fadeTime).OnComplete(() => SceneManager.LoadScene(scene));
    }


    public void Exit()
    {
        Application.Quit();
    }


    void OnDisable()
    {
        DOTween.KillAll();
    }
}
