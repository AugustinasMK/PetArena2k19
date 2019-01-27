using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateLauncher : MonoBehaviour
{
    public DogUltimate dogUltimate;

    public GameObject shootingPoopPrefab;

    public AudioClip shootSoundEffect;
    
    public float cooldown = 0.05f;

    private float time;

    public float shootingForce = 300f;

    public bool launcherEnabled = false;

    private void Start()
    {
        dogUltimate = FindObjectOfType<DogUltimate>();
    }

    public void EnableLauncher()
    {
        launcherEnabled = true;
        time = cooldown;

    }

 

    public void DisableLauncher()
    {
        launcherEnabled = false;
    }

    void Update()
    {

        time -= Time.deltaTime;
        if (time <= 0 && launcherEnabled)
        {
            LaunchProjectile();
            time = cooldown;
        }
    }

    private void LaunchProjectile()
    {
        

        GameObject projectile = Instantiate(shootingPoopPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rigidbody2D = projectile.GetComponent<Rigidbody2D>();

        AudioSource.PlayClipAtPoint(shootSoundEffect, Camera.main.transform.position);
        rigidbody2D.AddForce(Vector2.up * shootingForce + Vector2.right * UnityEngine.Random.Range(-10, 10) * 20);

    }
}
