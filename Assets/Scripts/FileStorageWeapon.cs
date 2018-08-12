using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileStorageWeapon : MonoBehaviour {

    public float damage;
    public float holdDamage;

    public float offset;
    public GameObject bulletProjectile;
    public GameObject bigBulletProjectile;
    public Transform bulletSpawnPos;

    private float timeBtwShots;
    public float startTimeBtwShots;
    private float timeBtwBigShots;
    public float startTimeBtwBigShots;

    void Update () {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Bullet bulletGO = Instantiate(bulletProjectile, bulletSpawnPos.position, transform.rotation).GetComponent<Bullet>();
                bulletGO.damage = damage;
                timeBtwShots = startTimeBtwShots;
                FindObjectOfType<AudioManager>().Play("Shoot");
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (timeBtwBigShots <= 0)
        {
            if (Input.GetMouseButton(1))
            {
                Bullet bulletGO = Instantiate(bigBulletProjectile, bulletSpawnPos.position, transform.rotation).GetComponent<Bullet>();
                bulletGO.damage = holdDamage;
                timeBtwBigShots = startTimeBtwBigShots;
                FindObjectOfType<AudioManager>().Play("Shoot");
            }
        }
        else
        {
            timeBtwBigShots -= Time.deltaTime;
        }
    }
}
