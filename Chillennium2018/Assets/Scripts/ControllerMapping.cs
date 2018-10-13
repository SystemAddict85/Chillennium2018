using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMapping : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("VerticalRight1") != 0)
            Debug.Log(Input.GetAxisRaw("VerticalRight1"));
    }
}
