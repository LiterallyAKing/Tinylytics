using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editorversiontest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


#if UNITY_2020
        Debug.Log("UNITY_2020");
#endif

#if UNITY_2019_1_OR_NEWER
        Debug.Log("UNITY_2019_1_OR_NEWER");
#endif

#if UNITY_2021
        Debug.Log("UNITY_2021");
#endif




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
