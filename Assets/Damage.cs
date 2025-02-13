using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] Material damageMat;
    [SerializeField] int health = 100;
    Material normalMat;
    MeshRenderer rend;
    bool isHurt, isDefeated;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        normalMat = rend.material;
        
    }

    // Update is called once per frame
    void Update()
    {
        print(health);
        if(health<= 0)
        {
            isDefeated = true;
        }
        else if(health < 30)
        {
            isDefeated = false;
            isHurt = true;
        }
        else
        {
            isDefeated = false;
            isHurt = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon"))
        {
            Transform weapon = other.transform.parent;
            
            if(weapon.TryGetComponent<Sword>(out Sword sword))
            {
                health -= sword.DealDamage();
            }
            StartCoroutine(DamageAnimation());
        }  
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            Transform weapon = collision.transform;
            if(weapon.TryGetComponent<Projectile>(out Projectile projectile))
            {
                health -= projectile.DealDamage();
            }
            StartCoroutine(DamageAnimation());
        }
    }

IEnumerator DamageAnimation()
    {
        rend.material = damageMat;
        if(isDefeated == false)
        {
            yield return new WaitForSeconds(0.1f);
            rend.material = normalMat;

            if(isHurt == true)
            {
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(DamageAnimation());
            }

        }
        else
        {
            yield return new WaitForSeconds(1);
            Destroy(transform.parent.gameObject);
        }    
        
    }
}
