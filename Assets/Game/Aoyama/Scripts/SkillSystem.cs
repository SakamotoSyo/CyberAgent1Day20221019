using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    /// <summary>
    /// �X�e�[�W���̖�������擾����p�̕ϐ�
    /// </summary>
    GameObject[] _lights;

    /// <summary>
    /// ���C�g�����Ă��邩��\���ϐ�
    /// </summary>
    public static bool _isLight = true;


    /// <summary>
    /// �X�L�������s���郁�\�b�h
    /// </summary>
    /// <param name="time">���������Ă��鎞��</param>
    public void LightOff(float time)
    {
    
        if (_lights == null)
        {
            Debug.Log("light delete");
            _lights = GameObject.FindGameObjectsWithTag("Light");
            Debug.Log(_lights);
        }
       
        StartCoroutine(SkillInterval(time));
    }


    IEnumerator SkillInterval(float time)
    {
        Debug.Log("skill");

        _isLight = false;
        _lights.ToList().ForEach(l => l.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 0.1f);
        Debug.Log("�X�L������");

        Debug.Log("skill");

        yield return new WaitForSeconds(time);

        Debug.Log("�X�L���I��");
        _lights.ToList().ForEach(l => l.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1f);
        _isLight = true;
    }
}
