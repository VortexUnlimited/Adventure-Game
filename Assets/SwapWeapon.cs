using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    [SerializeField] GameObject sword, gun;
    // Start is called before the first frame update
    void Start()
    {
        sword.SetActive(true);
        gun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            sword.SetActive(true);
            gun.SetActive(false);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            sword.SetActive(false);
            gun.SetActive(true);
        }
    }
}
