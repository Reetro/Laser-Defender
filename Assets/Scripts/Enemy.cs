using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] float health = 100;

    [Header("Projectile")]
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 0.3f;
    [SerializeField] GameObject laserPrefab = null;
    [SerializeField] GameObject explosionEffect = null;
    [SerializeField] float explosionDuration = 1f;

    [Header("Audio")]
    [SerializeField] AudioClip deathSFX = null;
    [SerializeField] AudioClip fireSFX = null;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.7f;
    [SerializeField] [Range(0, 1)] float fireSFXVolume = 0.7f;

    float shotCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomShot();
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0)
        {
            KillEnemy();

        }
    }

    private void KillEnemy()
    {
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);

        Destroy(gameObject);

        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;

        Destroy(explosion, explosionDuration);
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            Fire();

            SetRandomShot();
        }
    }

    private void SetRandomShot()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Fire()
    {
        AudioSource.PlayClipAtPoint(fireSFX, Camera.main.transform.position, fireSFXVolume);

        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }
}
