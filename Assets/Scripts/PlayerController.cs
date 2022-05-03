using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;




public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;

    public GameObject shot;
    public Transform shotSpawn1;
    public float fireRate;
    private float nextFire;

    private Rigidbody rig;
     
    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update(){
	    if(CrossPlatformInputManager.GetButton("Fire1") && Time.time>nextFire)
	    {
            nextFire = Time.time + fireRate;
		    Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
	    }
    }

    void FixedUpdate()
    {
        float movHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float movVertical = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(movHorizontal, 0f, movVertical);

        // velocidad
        rig.velocity = movement * speed;
        // Limites 
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, xMin, xMax), 0f, Mathf.Clamp(rig.position.z, zMin, zMax));
        // Rotacion
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
    }
}