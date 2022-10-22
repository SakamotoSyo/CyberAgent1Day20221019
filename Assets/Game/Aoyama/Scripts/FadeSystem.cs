using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class FadeSystem : MonoBehaviour
{
    [SerializeField, Tooltip("�t�F�[�h�Ɏg��Image")] Image _fadeImage;
    [SerializeField, Tooltip("�t�F�[�h�ɂ����鎞��")] float _fadeTime = 3f;


    public void StartFadeIn()//�t�F�[�h�C���֐� 
    {
        if (_fadeImage) _fadeImage.color = Color.black;
        _fadeImage.DOFade(endValue: 0f, duration: _fadeTime);
    }


    public void StartFadeOut(string scene)//�t�F�[�h�A�E�g�֐�
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
