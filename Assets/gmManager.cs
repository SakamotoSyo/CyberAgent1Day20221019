using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  gmManager : MonoBehaviour
{
    [SerializeField]FadeSystem fs;
    // Start is called before the first frame update
    void Start()
    {
        fs.StartFadeIn();
    }

}
