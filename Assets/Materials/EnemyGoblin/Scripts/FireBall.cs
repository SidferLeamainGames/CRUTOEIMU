using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float Speed;
    public Transform FireBallTransform;
    public float lifeTime;
    public float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireball", lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void MoveFixedUpdate()
    {
        FireBallTransform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyFireball();
        DamageEnemy(collision);
    }

    private void DestroyFireball()
    {
        Destroy(gameObject);
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }

        DestroyFireball();
    }
}