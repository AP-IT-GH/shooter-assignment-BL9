using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public float shootRate = 3f;

    float timer;
    bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool shoot = CrossPlatformInputManager.GetButton("Fire1");
        
        if (shoot && timer >= shootRate)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward * 2, transform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.VelocityChange);

            startTimer = true;
            timer = 0f;
        }
        else
        {
            if (timer < shootRate)
                timer += Time.deltaTime;
            else
            {
                timer = shootRate;
                startTimer = false;
            }
        }
    }
}
