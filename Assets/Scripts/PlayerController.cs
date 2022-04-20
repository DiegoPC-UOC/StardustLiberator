using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;

    private Rigidbody rig;
     
    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

 
    
    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movHorizontal, 0f, movVertical);

        // velocidad
        rig.velocity = movement * speed;
        // Limites 
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, xMin, xMax), 0f, Mathf.Clamp(rig.position.z, zMin, zMax));
        // Rotacion
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
    }
}
