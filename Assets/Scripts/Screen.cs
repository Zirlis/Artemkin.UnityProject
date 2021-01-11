using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject MainScreen;
    [SerializeField] GameObject MainText;

    private float playerSpeed;
    private float playerRotSpeed;
    private float playerForceOfJump;

    private bool start = false;

    private void Awake()
    {
        playerSpeed = player.speed;
        playerRotSpeed = player.rotSpeed;
        playerForceOfJump = player.forceOfJump;

        player.speed = 0f;
        player.rotSpeed = 0f;
        player.forceOfJump = 0f;
    }    

    void Update()
    {
        if(!start && Input.anyKeyDown)
        {
            player.speed = playerSpeed;
            player.rotSpeed = playerRotSpeed;
            player.forceOfJump = playerForceOfJump;

            start = true;
            MainScreen.GetComponent<Animation>().Play("increaseChangeOfScreen");
            MainText.GetComponent<Animation>().Play("increaseChangeOfText");
        }
    }   
}
