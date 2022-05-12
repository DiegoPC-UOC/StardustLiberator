using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_Boss : EnemyController
{
    [Header("Spawn & SpawnMovement")]
    public float spawnTime;
    public float speedMovement;
    [HideInInspector] public bool EndSpawn;
    Collider m_Collider;
    public override void Start()
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
    
    public override void FixedUpdate()
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
