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

    public void SetDefaultValue()
    {
        attack = 1;
        defense = 1;
        health = 1;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat",FileMode.Create);
        PlayerData playerDataToSave = new PlayerData();

        playerDataToSave.attack = attack;
        playerDataToSave.defense = defense;
        playerDataToSave.health = health;

        bf.Serialize(file, playerDataToSave);
        file.Close();
    }  

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 60, 180, 80),"Attaque : " + attack,style);
        GUI.Label(new Rect(10, 110, 180, 80),"Défense : " + defense,style);
        GUI.Label(new Rect(10, 160, 180, 80),"Vie : " + health,style);

    }
}

[Serializable] 
class PlayerData
{
    public int attack;
    public int defense;
    public int health;
}
