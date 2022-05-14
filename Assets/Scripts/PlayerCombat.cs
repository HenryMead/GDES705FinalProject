using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private float ammunition = 9;
    private bool enemyInRange;

    private void Update()
    {
        //ammunition
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit ");

            if (hit.transform.tag == "Enemy")
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && ammunition > 0)
                {
                    ammunition -= 1;

                    hit.transform.GetComponent<HealthModule>().Damage(1);
                    Debug.Log("Did Hit " + "ammo remaining: " + ammunition);
                }
            }
            
        }
        if (hit.collider == null && Input.GetKeyDown(KeyCode.Mouse0) && ammunition > 0)
        {
            ammunition -= 1;
        }
    }
}
