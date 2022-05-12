using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int powerupID;
    private float speed = 10;
    private Rigidbody rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rig.velocity = transform.forward * -speed;
    }
    void Update()
    {
        //transform.Translate(Vector3.back*Time.deltaTime,Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Colision con:" + other.name);
        if (other.name == "PlayerShip")
        {
            PlayerController player = other.GetComponent <PlayerController> ();
            DestroyByContact_Player playerShip = other.GetComponent<DestroyByContact_Player>();


            switch (powerupID)
            {
                case 0:
                    player.ShieldPowerUpOn();
                    break;
                case 1:
                    player.TripleShotPowerupOn();
                    break;
                case 2:
                    player.SpeedBoostPowerUpOn();
                    break;
                case 3:
                    playerShip.RecuperarVidaPowerUp();
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
