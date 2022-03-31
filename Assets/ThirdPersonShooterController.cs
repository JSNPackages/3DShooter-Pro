using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    
    private PhotonView view;
    public bool isMoving = false;

    public int value = 11;
    private float nextTimeToShoot = 0.2f;
    private float nextTimeToShootTimer;
    private int magazineSize = 15;
    private float reloadTime = 2.5f;
    private float reloadTimer;
    private int ammoLeftInMagazine;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    // Start is called before the first frame update
    void Start()
    {
        this.view = GetComponent<PhotonView>();
        ammoLeftInMagazine = magazineSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.view.IsMine) return;
        nextTimeToShootTimer += Time.deltaTime;
        
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }
        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            
        }
        if (starterAssetsInputs.shoot && nextTimeToShootTimer >= nextTimeToShoot && ammoLeftInMagazine > 0)
        {
            if (hitTransform != null)
            {
                ammoLeftInMagazine -= 1;
                
                if (hitTransform.GetComponent<BulletTarget>() != null)
                {

                    FindObjectOfType<BulletTarget>().TakeDamage(value);
                }
                else
                {
                    print("Hit something other than enemy");
                }
            
            }
            starterAssetsInputs.shoot = false;
            nextTimeToShootTimer = 0f;
        }
        if (ammoLeftInMagazine == 0)
        {
            
            reloadTimer += Time.deltaTime;

            if (reloadTimer >= reloadTime)
            {

                ammoLeftInMagazine = magazineSize;
                reloadTimer = 0f;
            }
        }


    }
   
   
}
