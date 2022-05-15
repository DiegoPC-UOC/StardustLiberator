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
    
    //PowerUp que nos permitira tener activo el triple disparo
    public bool canTripleShot = false;

    //PowerUp que nos permitira aumentar la velocidad
    public bool canSpeedBoost = false;

    //PowerUp que nos permitira activar el escudo
    public bool haveShield = false;

    public GameObject Shield;

    private Rigidbody rig;


    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update(){
	    if(CrossPlatformInputManager.GetButton("Fire1") && Time.time>nextFire)
	    {
            //En caso de activar el powerUp se activan los tres disparos.
            if (canTripleShot == true)
            {
                Instantiate(shot, transform.position + new Vector3 (0, 0, 5), Quaternion.identity);
                Instantiate(shot, transform.position + new Vector3(4, 0, -1), Quaternion.identity);
                Instantiate(shot, transform.position + new Vector3(-4, 0, -1), Quaternion.identity);
                nextFire = Time.time + fireRate; //Para evitar disparar muy rapido
            } 
            else
            {
                Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
            }
            nextFire = Time.time + fireRate;

        }

        //Modificacion de la velocidad cuando se activa el power up Speed
        if (canSpeedBoost == true)
        {
            speed = 50.0f;
        }
        else
        {
            speed = 35.0f;
        }

   
    }
    
    //Funcion Triple Shoot, con llamada a la rutina para finalizar el power up pasados unos segundos
    public void TripleShotPowerupOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    //Funcion Speed, con llamada a la rutina para finalizar el power up pasados unos segundos
    public void SpeedBoostPowerUpOn()
    {
        canSpeedBoost = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    //Funcion Shield, con llamada a la rutina para finalizar el power up pasados unos segundos
    public void ShieldPowerUpOn()
    {
        haveShield = true;
        Shield.SetActive(true);
        StartCoroutine(ShieldPowerDownRoutine());
    }

    //Rutinas que limitan el tiempo de la duraci�n de los PowerUps
    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(7.0f);
        canTripleShot = false;
    }

    public IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canSpeedBoost = false;
    }

    public IEnumerator ShieldPowerDownRoutine()
    {
        yield return new WaitForSeconds(10.0f);
        Shield.SetActive(false);
        haveShield = false;
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