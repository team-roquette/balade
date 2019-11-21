using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public static Characters characters;
    public static GameObject[] charactersList = new GameObject[2]; 
    public static Transform[] charactersTransform = new Transform[2];

    void Awake() {
        if(characters == null) {
            DontDestroyOnLoad(gameObject);
            characters = this;
        } else if(characters != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        GetCharactersGameObject();
        GetCharactersTransform();
    }

    void GetCharactersGameObject() { 
        charactersList[0] = GameObject.Find("Player"); 
        charactersList[1] = GameObject.Find("Boyfriend");
    }

    void GetCharactersTransform() {
        for (int i = 0; i > charactersList.Length ; i ++) {
            charactersTransform[i] = charactersList[i].transform;
        }
    }
}
