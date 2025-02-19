using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    bool isShooting;
    public float force;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        isShooting = false;
    }
    void Update()
    {
        if(isShooting == false && Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject newPro = Instantiate(projectile);
            newPro.transform.position = transform.position;
            newPro.transform.rotation = transform.rotation;
            newPro.GetComponent<Rigidbody>().AddForce(transform.up*force);
            StartCoroutine(ShootDelay());
        }
    }

    IEnumerator ShootDelay()
    {
        isShooting = true;
        yield return new WaitForSeconds(1);
        isShooting = false;
    }
}
