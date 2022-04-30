using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvasion : MonoBehaviour
{
    public float speedMovement;
    public float smoth;
    public float tilt;
    public Vector2 startWait;
    public Vector2 movementTime;
    public Vector2 movementWait;
    private float evadeSpeed;
    private Rigidbody rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    void Start()
    {
        StartCoroutine(Evade());
    }
    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while(true)
        {

        evadeSpeed = Random.Range(1, speedMovement) * -Mathf.Sign(transform.position.x);

        yield return new WaitForSeconds(Random.Range(movementTime.x, movementTime.y));

        evadeSpeed = 0;

        yield return new WaitForSeconds(Random.Range(movementWait.x, movementWait.y));
        
        }

    }
    void FixedUpdate()
    {
        float acceletare = Mathf.MoveTowards(rig.velocity.x, evadeSpeed, Time.deltaTime * smoth);
        rig.velocity = new Vector3(acceletare, 0.0f, rig.velocity.z);
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
    }
}