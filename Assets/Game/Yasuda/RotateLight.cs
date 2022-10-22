using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yasuda{
    public class RotateLight : MonoBehaviour
    {
        [SerializeField]private float rotateAngle;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.Rotate(new Vector3(0,0,rotateAngle) * Time.deltaTime);
        }
    }
}

