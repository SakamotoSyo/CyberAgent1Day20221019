using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    /// <summary>
    /// ステージ内の明かりを取得する用の変数
    /// </summary>
    GameObject[] _lights;

    /// <summary>
    /// ライトがついているかを表す変数
    /// </summary>
    public static bool _isLight;


    /// <summary>
    /// スキルを実行するメソッド
    /// </summary>
    /// <param name="time">光が消えている時間</param>
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
        Debug.Log("スキル発動");

        yield return new WaitForSeconds(time);

        Debug.Log("スキル終了");
        _lights.ToList().ForEach(l => l.SetActive(true));
        _isLight = true;
    }
}
