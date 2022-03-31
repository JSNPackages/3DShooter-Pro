using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform BulletSpawnPoint;
    public float TimeToWaitBeforeShoot = 0.1f;
    public float TimerToShoot;
    public float MagazineSize = 30;
    public float ReloadTime = 2;
    public float BulletsLeft;



    public float TimerToReload;

    // Start is called before the first frame update
    void Start()
    {
        BulletsLeft = MagazineSize;
    }

    // Update is called once per frame
    void Update()
    {
        TimerToShoot += Time.deltaTime;
        TimerToReload += Time.deltaTime;
        if (Input.GetButton("Fire1") && TimerToShoot >= TimeToWaitBeforeShoot && BulletsLeft > 0 && TimerToReload >= ReloadTime)
        {
            Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            TimerToShoot = 0;
            if (TimerToShoot == 0)
            {
                BulletsLeft -= 1;
            }
            if (BulletsLeft <= 0)
            {

                BulletsLeft = MagazineSize;
                TimerToReload = 0;
            }
        }
    }

}