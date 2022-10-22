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
    public static bool _isLight;


    /// <summary>
    /// �X�L�������s���郁�\�b�h
    /// </summary>
    /// <param name="time">���������Ă��鎞��</param>
    public void LightOff(float time)
    {
        if (_lights == null)
        {
            _lights = GameObject.FindGameObjectsWithTag("Light");
        }
       
        SkillInterval(time);
    }


    IEnumerator SkillInterval(float time)
    {
        _isLight = false;
        _lights.ToList().ForEach(l => l.SetActive(false));
        Debug.Log("�X�L������");

        yield return new WaitForSeconds(time);

        Debug.Log("�X�L���I��");
        _lights.ToList().ForEach(l => l.SetActive(true));
        _isLight = true;
    }
}
