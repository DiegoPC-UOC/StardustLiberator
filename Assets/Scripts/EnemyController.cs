using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float speedEvasion;
    public float smoth;
    public float tilt;
    public Vector2 startWait;
    public Vector2 movementTime;
    public Vector2 movementWait;
    [HideInInspector] public float evadeSpeed;
    [HideInInspector] public Rigidbody rig;
    public virtual void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    public virtual void Start()
    {
        rig.velocity = transform.forward * -speed;
        StartCoroutine(Evade());
    }
    public virtual void FixedUpdate()
    {
        float acceletare = Mathf.MoveTowards(rig.velocity.x, evadeSpeed, Time.deltaTime * smoth);
        rig.velocity = new Vector3(acceletare, 0.0f, rig.velocity.z);
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
    }
    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while(true)
        {
            evadeSpeed = Random.Range(1, speedEvasion) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(movementTime.x, movementTime.y));
            evadeSpeed = 0;
            yield return new WaitForSeconds(Random.Range(movementWait.x, movementWait.y));
        }

    }
}
