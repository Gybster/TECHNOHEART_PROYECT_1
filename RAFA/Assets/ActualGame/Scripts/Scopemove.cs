using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Scopemove : MonoBehaviour
{
    public float zpos = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = zpos;
        transform.position = cursorPos;
    }
}
