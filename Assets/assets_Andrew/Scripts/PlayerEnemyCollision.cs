using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages player and enemy collision
//Put on player character (Mario) with marioHealthDeath script
public class PlayerEnemyCollision : MonoBehaviour
{
    private marioHealthDeath marioHealthScript;
    private Rigidbody rb;

    public GameObject coin; //assign coin prefab in inspector
    
    private float immunityTimer; //timer that tracks whether Mario is currently immune or not, 0 = not immune
    public float immunityDuration = 1.0f; //how long Mario is immune for after taking damage

    private bool onFire = false;
    
    public float goombaBounceHeight = 15;
    public float knockbackForce = 15; //power of knockback when player touches enemy
    
    void Start()
    {
        marioHealthScript = GetComponent<marioHealthDeath>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (immunityTimer > 0)
        {
            immunityTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("goomba")) //if collision object is a goomba
        {
            if (transform.position.y - collision.transform.position.y > 1.0f
            ) //check difference in y-position to see if Mario is above enemy, 1.0f is an arbitrary number
            {
                rb.AddForce(Vector3.up * goombaBounceHeight, ForceMode.Impulse);
                Destroy(collision.gameObject); //destroy enemy if true

                //Instantiate a coin where goomba died
                GameObject spawnedCoin = Instantiate(coin, transform.position + Vector3.up / 2, Quaternion.identity);
                spawnedCoin.GetComponent<Rigidbody>().isKinematic = false;
                spawnedCoin.GetComponent<Rigidbody>().AddForce(Vector3.up * 2f, ForceMode.Impulse);
                spawnedCoin.GetComponent<coinscript>().pickupWaitTime = 0.5f;
                spawnedCoin.GetComponent<BoxCollider>().enabled = true;
                //Audio for killing Goomba 
                AudioManager.Instance.PlayAudioClip(AudioManager.Instance.GoombaDeathSound);

            }
            else
            {
                //if collision object is an "enemy" but Mario is not above it, take damage and get knocked backwards

                if (immunityTimer <= 0)
                {
                    marioHealthScript.TakeDamage();
                    Vector3 enemyPos = collision.gameObject.transform.position;
                    Vector3 knockbackVector = ((transform.position - enemyPos)).normalized;
                    rb.AddForce(knockbackVector * knockbackForce, ForceMode.Impulse);
                    collision.gameObject.GetComponent<Rigidbody>()
                        .AddForce(knockbackVector * knockbackForce * -1, ForceMode.Impulse);
                    immunityTimer = immunityDuration;
                }

            }
        }

        if (collision.gameObject.CompareTag("electric")) //if collision object is an electric enemy
        {
            if (immunityTimer <= 0)
            {
                marioHealthScript.TakeDamage();
                Vector3 enemyPos = collision.gameObject.transform.position;
                Vector3 knockbackVector = ((transform.position - enemyPos)).normalized;
                rb.AddForce(knockbackVector * knockbackForce, ForceMode.Impulse);
                immunityTimer = immunityDuration;
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("fire") && !onFire) //if collision object is an electric enemy
        {
            onFire = true;
            StartCoroutine(OnFire());
        }
    }

    IEnumerator OnFire()
    {
        marioHealthScript.TakeDamage();
        yield return new WaitForSeconds(0.5f);
        marioHealthScript.TakeDamage();
        yield return new WaitForSeconds(0.5f);
        marioHealthScript.TakeDamage();
        onFire = false;
    }
}
