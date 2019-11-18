using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {
    public static GameController gameControl;

    public int attack;
    public int defense;
    public int health;
    public int currentWeapon;

    public List<Weapon> listWeapon = new List<Weapon>();

	// Use this for initialization
	void Start () {

        if (gameControl == null)
        {
            DontDestroyOnLoad(gameObject);
            gameControl = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SetDefaultValue();
    }

    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (!File.Exists(Application.persistentDataPath + "gameInfo.dat"))
        {
            throw new Exception("Fichier du jeu innexistant");
        }

        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat", FileMode.Open);
        PlayerData playerDataToLoad = (PlayerData)bf.Deserialize(file);
        file.Close();

        attack = playerDataToLoad.attack;
        defense = playerDataToLoad.defense;
        health = playerDataToLoad.health;
        listWeapon = playerDataToLoad.listWeapon;
        currentWeapon = playerDataToLoad.currenWeapon;
    }

    public void AddWeapon()
    {
        listWeapon.Add(new Weapon());
    }

    public void NextWeapon()
    {
        if (currentWeapon == listWeapon.Count - 1)
        {
            currentWeapon = 0;
        }
        else
        {
            currentWeapon++;
        }
    }

    public void PreviousWeapon()
    {
        if (currentWeapon == 0)
        {
            currentWeapon = listWeapon.Count - 1;
        }
        else
        {
            currentWeapon--;
        }
    }


    public void AddAttack()
    {
        attack++;
    }

    public void AddDefense()
    {
        defense++;
    }

    public void AddHealth()
    {
        health++;
    }

    public void AddDamageToWeapon()
    {
        listWeapon[currentWeapon].damage += 1;
    }

    public void SetDefaultValue()
    {
        attack = 1;
        defense = 1;
        health = 1;
        currentWeapon = 0;
        listWeapon = new List<Weapon>();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat",FileMode.Create);
        PlayerData playerDataToSave = new PlayerData();
    

        playerDataToSave.attack = attack;
        playerDataToSave.defense = defense;
        playerDataToSave.health = health;
        playerDataToSave.currenWeapon = currentWeapon;
        playerDataToSave.listWeapon = listWeapon;

        bf.Serialize(file, playerDataToSave);
        file.Close();
    }  

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 80,180, 80),"Attaque : " + attack,style);
        GUI.Label(new Rect(10, 130, 180, 80),"Défense : " + defense,style);
        GUI.Label(new Rect(10, 180, 180, 80),"Vie : " + health,style);
        GUI.Label(new Rect(10, 230, 180, 80), "#Arme : " + currentWeapon, style);

        if (listWeapon.Count > 0)
        {
            GUI.Label(new Rect(10, 280, 180, 80), "Arme Damage : " + listWeapon[currentWeapon].damage, style);
        }
    }
}

[Serializable] 
class PlayerData
{
    public int attack;
    public int defense;
    public int health;
    public int currenWeapon;
    public List<Weapon> listWeapon;
}

[Serializable]
public class Weapon
{
    public int damage; 

    public Weapon()
    {
        damage = 1;
    }
}



