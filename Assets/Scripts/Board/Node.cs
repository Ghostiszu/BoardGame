using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Node : MonoBehaviour
{
    public enum SpaceType {Combat, Shop, Itembox, MagicBox, Rest}
    [SerializeField] GameManager gameManager;
    public SpaceType spaceType;

    public static GameObject playerOnNode;

    // Start is called before the first frame update

    public void StartEvent(GameObject player)
    {
        if(spaceType == SpaceType.Combat)
        {
            playerOnNode = player;
            gameManager.StartBattle();
            //Load Battle Scene
        }
        if(spaceType == SpaceType.Shop)
        {

        }
        if(spaceType == SpaceType.Itembox)
        {

        }
        if(spaceType == SpaceType.MagicBox)
        {

        }
        if(spaceType == SpaceType.Rest)
        {

        }
        

        
    }
}
