using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator ani;
    [SerializeField] public int damage = 10;
    [SerializeField] public float critChance = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && ani.GetBool("isAttacking") == false)
        {
            ani.SetBool("isAttacking",true);
        }
    }

    public void StopAttacking()
    {
        ani.SetBool("isAttacking", false);
    }
    
    public int DealDamage()
    {
        if(Random.Range(0f,1f) > critChance)
        {
            return damage;
        }

        return (int)Mathf.Floor( damage * 1.5f);
            
    }
}
