using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public static Characters characters;
    public static Transform[] charactersList = new Transform[2]; 

    void Awake() {
        if(characters == null) {
            DontDestroyOnLoad(gameObject);
            characters = this;
        } else if(characters != this) {
            Destroy(gameObject);
        }
    }

    void Start() {

        charactersList[0] = GameObject.Find("Player").transform; 
        charactersList[1] = GameObject.Find("Boyfriend").transform;
    }
}
