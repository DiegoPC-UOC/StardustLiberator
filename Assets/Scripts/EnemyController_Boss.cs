using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_Boss : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float spawnTime;
    public bool EndSpawn;
    private Rigidbody rig;
    public float speedMovement;
    public float smoth;
    public float tilt;
    public Vector2 startWait;
    public Vector2 movementTime;
    public Vector2 movementWait;
    private float evadeSpeed;

    Collider m_Collider;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Start()
    {

        m_Collider = GetComponent<Collider>();
        StartCoroutine(Mover());

    }
    IEnumerator Mover()
    {
        yield return new WaitForSeconds(2);

        while(!EndSpawn)
        {
        
            rig.velocity = transform.forward * -speed;

            yield return new WaitForSeconds(spawnTime);

            rig.velocity = transform.forward * 0;

            EndSpawn = true;
        
        }

        yield return new WaitForSeconds(2);

        while(EndSpawn)

            {

                evadeSpeed = Random.Range(1, speedMovement) * -Mathf.Sign(transform.position.x);
                yield return new WaitForSeconds(Random.Range(movementTime.x, movementTime.y));
                evadeSpeed = 0;
                yield return new WaitForSeconds(Random.Range(movementWait.x, movementWait.y));
            
            }

    }
    
    void FixedUpdate()
    {
        if (!EndSpawn)
        {
            m_Collider.enabled = false;
        }
        else 
        {
            m_Collider.enabled = true;
        }

        float acceletare = Mathf.MoveTowards(rig.velocity.x, evadeSpeed, Time.deltaTime * smoth);
        rig.velocity = new Vector3(acceletare, 0.0f, rig.velocity.z);
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
    }
}
