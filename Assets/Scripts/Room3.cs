using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room3 : MonoBehaviour
{
    [SerializeField] GameObject MainScreen;
    [SerializeField] GameObject MainText;
    [SerializeField] Player player;

    private Animation transparencyChangeOfScreen;
    private Animation transparencyChangeOfText;

    private bool enterInRoom3 = false;
    private bool canBeRemoved = false;

    private float playerSpeed;
    private float playerRotSpeed;
    private float playerForceOfJump;

    private void Awake()
    {
        transparencyChangeOfScreen = MainScreen.GetComponent<Animation>();
        transparencyChangeOfText = MainText.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!enterInRoom3 && other.CompareTag("Player"))
        {
            enterInRoom3 = true;
            MainText.GetComponent<Text>().text = "Выход \n Выход \n Выход \n \n \n \n \n Нажмите любую клавишу чтобы продолжить";
            transparencyChangeOfScreen.Play("transparencyChangeOfScreen");
            transparencyChangeOfText.Play("transparencyChangeOfText");
            Invoke("CanBeRemoved", transparencyChangeOfText["transparencyChangeOfText"].length);

            playerSpeed = player.speed;
            playerRotSpeed = player.rotSpeed;
            playerForceOfJump = player.forceOfJump;

            player.speed = 0f;
            player.rotSpeed = 0f;
            player.forceOfJump = 0f;
        }
    }

    private void CanBeRemoved()
    {
        canBeRemoved = true;
    }

    void Update()
    {
        if (canBeRemoved && Input.anyKeyDown)
        {
            canBeRemoved = false;
            player.speed = playerSpeed;
            player.rotSpeed = playerRotSpeed;
            player.forceOfJump = playerForceOfJump;

            MainScreen.GetComponent<Animation>().Play("increaseChangeOfScreen");
            MainText.GetComponent<Animation>().Play("increaseChangeOfText");

            Destroy(gameObject);
        }
    }
}
