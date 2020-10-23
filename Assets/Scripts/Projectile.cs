using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] int damage = 50;
    [SerializeField] GameObject explosionVFX;

    [Header("Slow Settings")]
    [SerializeField] bool hasSlow = false;
    [Range(0f, 1f)][SerializeField] float slowAmount = 0f;
    [SerializeField] float slowTime = 0f;

    [Header("Explosion Settings")]
    [SerializeField] bool hasExplosion = false;
    [SerializeField] Vector2 range = new Vector2(1,1);
    [SerializeField] bool showRangeInEditor = false;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float explosionDamage = 0;
    [SerializeField] float explosionSlowAmount = 0;
    [SerializeField] float explosionSlowTime = 0;

    float z;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime, Space.World);

        z += Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, -z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasExplosion)
            TriggerExplosion(collision);
        else
            HitAttacker(collision);

        DestroyProjectile();
    }


    void TriggerExplosion(Collider2D originalEnemy)
    {
        foreach(Collider2D enemy in EnemiesInRange())
        {
            if (!enemy.Equals(originalEnemy))
                HitAttacker(enemy, true);
            else
                HitAttacker(enemy);
        }
    }

    void HitAttacker(Collider2D attacker, bool secondaryTarget = false)
    {
        Health healthObject = attacker.gameObject.GetComponent<Health>();
        Attacker attackerObject = attacker.gameObject.GetComponent<Attacker>();

        healthObject.DealDamage(secondaryTarget ? explosionDamage : damage);
        if (hasSlow) attackerObject.Slow(
            secondaryTarget ? explosionSlowTime : slowTime,
            secondaryTarget ? explosionSlowAmount : slowAmount
        );
    }

    Collider2D[] EnemiesInRange()
    {
        return Physics2D.OverlapBoxAll(gameObject.transform.position, range, 0, layerMask);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if(showRangeInEditor)
            Gizmos.DrawWireCube(transform.position, range);
    }

    void DestroyProjectile()
    {
        GameObject explosionVFXInstance = Instantiate(explosionVFX, transform.position, Quaternion.identity);

        Destroy(explosionVFXInstance, 1f);
        Destroy(gameObject);
    }
}
