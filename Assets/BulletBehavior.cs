using System.Collections;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float BULLET_TIME = 3f;
    public int BOUNCE_MAX = 5;

    public float damage;
    public GameObject bulletSource;

    private Rigidbody rb;
    private Vector3 lastVelocity;
    private int bounces = 0;

    void Start()
    {
        // Make bullets bounce smoothly
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.useGravity = false;
        rb.drag = 0f;
        rb.angularDrag = 0f;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;

        StartCoroutine(BulletTimeOut());
        // Visualize
        Debug.DrawRay(transform.position, rb.velocity, Color.red, 0.2f);

    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    IEnumerator BulletTimeOut()
    {
        yield return new WaitForSeconds(BULLET_TIME);
        Debug.Log("Bullet Killed!");
        KillBullet();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (bulletSource && collision.gameObject.CompareTag(bulletSource.tag) && bounces == 0)
            return;

        var damagable = collision.gameObject.GetComponent<iDamagable<float>>();
        if (damagable != null)
        {
            Debug.Log("Bullet Hit " + collision.gameObject.name);
            damagable.takeDamage(damage);
            KillBullet();
            return;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            if (bounces < BOUNCE_MAX)
            {
                Bounce(collision);
            }
            else
            {
                Debug.Log("Bounced out! " + collision.gameObject);
                KillBullet();
            }
        }
        else
        {
            Debug.Log("Hit non-damaging object: " + collision.gameObject);
        }
    }

    void Bounce(Collision collision)
    {
        Debug.Log("Bounce! " + collision.gameObject);
        ContactPoint contact = collision.contacts[0];
        Vector3 reflectedVelocity = Vector3.Reflect(lastVelocity, contact.normal).normalized * lastVelocity.magnitude;
        reflectedVelocity.y = 0f; // Force flat bounce
        rb.velocity = reflectedVelocity;
        bounces++;
    }

    void KillBullet()
    {
        // TODO: Object pooling
        Destroy(gameObject);
    }
}
