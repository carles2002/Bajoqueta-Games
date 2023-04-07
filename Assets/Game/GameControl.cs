using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private bool gameRunning;
    public void ChangeGameRunningState(){
        gameRunning = !gameRunning;
        if(gameRunning){
            //El juego está en curso --> Running

        }
        else{
            //El juego está pausado --> No Running
        }
        //Esto servirá para cuando queramos hacer el menú de pausa ;D
    }

    public bool IsGameRunning(){
        return gameRunning;
    }
}
