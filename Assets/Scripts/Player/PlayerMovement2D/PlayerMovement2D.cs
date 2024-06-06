using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");

        if (movement < 0)
        {
            transform.forward = Vector3.left;
        }else if (movement > 0)
        {
            transform.forward = Vector3.right;
        }
        transform.position += Vector3.right * speed * movement * Time.deltaTime;
    }
}
