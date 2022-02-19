using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{

    public void Upgrade(int weaponLevel)
    {

        switch (weaponLevel)
        {
            //Extra use once items:  astroid rain on enemys

           
            case 1: //Increase player shooting speed
                FindObjectOfType<Player>()._curAttackTimerc = 0.2f;

                Debug.Log("Increased Player Speed!");
                break;
            //hold and shoot stråle on buttonpress?
            // Two shooters slow
            

            //Shoot up-right & down-left Tribullet
            case 2:

                break;


            // Two shooters fast & purple
            case 3:
                break;

            // Spinning fire bullet / Pet that shoots?
            case 4:
                break;
            case 5:
                break;


            default:
                break;
        }
    }
}
