using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public CharacterController controller;
    public new Camera camera;

    public float bulletSpeed = 6.0f;


    public float playerSpeed = 12f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * playerSpeed * Time.deltaTime);
        //Time. deltaTime allows you to move things not by frame (which would be too fast or too slow depending on your hardware) but rather the time in seconds it took to complete the last frame

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Create a ray from the camera going through the middle of your screen
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        // Check whether your are pointing to something so as to adjust the direction
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(1000);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = (targetPoint - bulletSpawn.transform.position).normalized * bulletSpeed;
    }
}
