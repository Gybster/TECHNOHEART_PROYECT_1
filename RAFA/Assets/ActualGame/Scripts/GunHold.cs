using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHold : MonoBehaviour
{
    public PlayerController myplayerscript;

    private Camera maincam;
    private Vector3 mousePos;
 


    // Start is called before the first frame update
    void Start()
    {

        maincam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
 
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = maincam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,rotZ);
    }
}
