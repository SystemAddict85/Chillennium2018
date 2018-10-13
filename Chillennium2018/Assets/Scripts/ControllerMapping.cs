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
        if (Input.GetAxisRaw("Vertical2") != 0)
            Debug.Log(Input.GetAxisRaw("Vertical2"));
    }
}
