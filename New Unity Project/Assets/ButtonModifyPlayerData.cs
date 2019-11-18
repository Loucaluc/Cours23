using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonModifyPlayerData : MonoBehaviour {

    public void AddAttack()
    {
        GameController.gameControl.AddAttack();
    }

    public void AddDenfense()
    {
        GameController.gameControl.AddDefense();
    }

    public void AddHealth()
    {
        GameController.gameControl.AddHealth();
    }
}
