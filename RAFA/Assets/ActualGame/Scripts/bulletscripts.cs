using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscripts : MonoBehaviour
{
    [SerializeField] public float bullspeed = 1f;
    public GunHold gunhold;
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0f, 0f, -90f);
        if (direction == -1)
        {
            transform.Rotate(0f, 0f, 180f);
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(bullspeed* direction, 0f, 0f) * Time.deltaTime;

        // Destroy the bullet if it goes off screen
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);  
        }
        // A method to activate the GameObject containing this script
        

    }
    public void ActivateBullet()
    {
        gameObject.SetActive(true);
    }
}
