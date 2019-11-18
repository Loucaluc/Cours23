using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWeapon : MonoBehaviour {

    public void NextWeapon()
    {
        GameController.gameControl.NextWeapon();
    }

    public void PreviousWeapon()
    {
        GameController.gameControl.PreviousWeapon();
    }

    public void AddDamageToWeapon()
    {
        GameController.gameControl.AddDamageToWeapon();
    }
    public void AddWeapon()
    {
        GameController.gameControl.AddWeapon();
    }
}
