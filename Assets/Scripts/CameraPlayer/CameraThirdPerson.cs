using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraThirdPerson : MonoBehaviour {

    [Header("Object Selections")]
    public Transform camPlace;
    public Transform camHotspot;
    public Transform playerBody;
    public Transform playerHead;
    public Transform playerCanon;
    public GameObject missile;
    public Camera mainCam;

    [Header("Camera Settings")]
    public float camSpeed = 50;
    public float sensitivityX = 50;
    public float sensitivityY = 50;

    [Header("Player Settings")]
    public float playerSpeed;
    public float playerRotationSpeed = 5f;

    [Header("Weapon Settings")]
    public float playerCanonForce = 20f;
    public float playerShootRecoil = 10f;
    public int totalAmmo = 10;
    public float delayAttack = 2f;

    [Header("UI Settings")]
    public Image reloadingFeedback;
    public Text remainingAmmoText;

    bool canMakeFire;
    bool attackReloading;
    float axisX;
    float axisY;

    private void Start()
    {
        remainingAmmoText.text = totalAmmo.ToString();
    }

    private void Update()
    {
        // Take axis
        axisX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        axisY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        // Move tank head
        playerHead.transform.Rotate(0, axisX, 0);

        // Move tank
        if (Input.GetButton("GoForward"))
        {
            playerBody.transform.position += playerBody.forward * playerSpeed * Time.deltaTime;
        }
        if (Input.GetButton("GoBack"))
        {
            playerBody.transform.position += -playerBody.forward * playerSpeed * Time.deltaTime;
        }
        if (Input.GetButton("GoLeft"))
        {
            playerBody.transform.Rotate(0, -playerRotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetButton("GoRight"))
        {
            playerBody.transform.Rotate(0, playerRotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetButton("ResetView"))
        {
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPlace.transform.position, camSpeed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Fire1") && !attackReloading && canMakeFire)
        {
            // Create recoil
            gameObject.GetComponent<Rigidbody>().AddForce(-gameObject.transform.forward * playerShootRecoil, ForceMode.Impulse);

            // Remove one ammo
            totalAmmo--;
            remainingAmmoText.text = totalAmmo.ToString();

            // Set time to reload
            attackReloading = true;
            StartCoroutine(WaitToReload());

            // Create a missile
            GameObject newMissile = GameObject.Instantiate(missile);
            newMissile.transform.position = playerCanon.transform.position;
            newMissile.GetComponent<Rigidbody>().AddForce(playerHead.transform.forward * playerCanonForce, ForceMode.Impulse);
            newMissile.transform.rotation = playerHead.transform.rotation;
        }

        if (totalAmmo <= 0)
        {
            canMakeFire = false;
        }
        else
        {
            canMakeFire = true;
        }
        
    }

    // Used to move camera
    private void LateUpdate()
    {
        mainCam.transform.LookAt(camHotspot.transform);
        //mainCam.transform.RotateAround(camHotspot.transform.position, new Vector3(axisY, 0, 0), camSpeed * Time.deltaTime);
        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, camPlace.transform.position, camSpeed * Time.deltaTime);
    }

    IEnumerator WaitToReload()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(delayAttack / 100f);
            reloadingFeedback.fillAmount = i / 100f;
        }
        attackReloading = false;
    }

}
