using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunshot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canfire;
    private float timer;
    public float firerate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canfire)
        {
            timer += Time.deltaTime;
            if (timer > firerate)
            {
                canfire = true;
                timer = 0; //AQUI
            }
        }


        if (Input.GetMouseButtonDown(0) && canfire)
        {
            canfire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }

    }
    
}
