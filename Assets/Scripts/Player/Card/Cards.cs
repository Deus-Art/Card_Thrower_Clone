using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cards : MonoBehaviour
{
    public GameData gameData;
    public GameManager gameManager;
    public GameObject cardPrefab;

    float decreaseCooldown = 0.04f;
    

    void Update() 
    {
        ThrowCard();
        Dualies();
        Spread();    
        SpreadWithDualies();
        CheckSpreadDualiesBool();
       
    }
    void ThrowCard()
    {
        if(gameManager.isThrowing == true)
        {
            gameManager.card_Cooldown -= decreaseCooldown;

            if(gameManager.card_Cooldown <= 0)
            {
                GameObject card = Instantiate(cardPrefab, transform.position, transform.rotation);
                Rigidbody rb = card.GetComponent<Rigidbody>();
                rb.velocity = Vector3.forward * 8f;
                Destroy(card, gameManager.ingame_Range);

                if(gameManager.card_Cooldown <= 0)
                {
                    gameManager.card_Cooldown = gameManager.ingame_throwRate;
                }
            }
        }
        
    }

    void Dualies()
    {
        if(gameManager.ingame_Dualies == true)
        {
            

            gameManager.card_Cooldown -= decreaseCooldown;

            if(gameManager.card_Cooldown <= 0)
            {

                GameObject cardLeft = Instantiate(cardPrefab, transform.position - new Vector3(-0.25f, 0f, 0f), transform.rotation);
                Rigidbody rbLeft = cardLeft.GetComponent<Rigidbody>();
                rbLeft.velocity = Vector3.forward * 8f;
                Destroy(cardLeft, gameManager.ingame_Range);


                GameObject cardRight = Instantiate(cardPrefab, transform.position - new Vector3(0.25f, 0f, 0f), transform.rotation);
                Rigidbody rbRight = cardRight.GetComponent<Rigidbody>();
                rbRight.velocity = Vector3.forward * 8f;
                Destroy(cardRight, gameManager.ingame_Range);

                

                if(gameManager.card_Cooldown <= 0)
                {
                    gameManager.card_Cooldown = gameManager.ingame_throwRate;
                }
            }
        }
    }

    void Spread()
    {
        if(gameManager.ingame_Spread == true)
        {
            

            gameManager.card_Cooldown -= decreaseCooldown;

            if(gameManager.card_Cooldown <= 0)
            {

                GameObject cardLeft = Instantiate(cardPrefab, transform.position - new Vector3(0.25f, 0f, 0f), transform.rotation);
                Rigidbody rbLeft = cardLeft.GetComponent<Rigidbody>();
                rbLeft.velocity = Vector3.forward * 8f + Vector3.left;
                Destroy(cardLeft, gameManager.ingame_Range);


                GameObject cardCenter = Instantiate(cardPrefab, transform.position, transform.rotation);
                Rigidbody rbCenter = cardCenter.GetComponent<Rigidbody>();
                rbCenter.velocity = Vector3.forward * 8f;
                Destroy(cardCenter, gameManager.ingame_Range);


                GameObject cardRight = Instantiate(cardPrefab, transform.position - new Vector3(-0.25f, 0f, 0f), transform.rotation);
                Rigidbody rbRight = cardRight.GetComponent<Rigidbody>();
                rbRight.velocity = Vector3.forward * 8f + Vector3.right;
                Destroy(cardRight, gameManager.ingame_Range);

                

                if(gameManager.card_Cooldown <= 0)
                {
                    gameManager.card_Cooldown = gameManager.ingame_throwRate;
                }
            }
        }
    }

    void SpreadWithDualies()
    {
        if(gameManager.ingame_SpreadDualies == true)
        {
            

            gameManager.card_Cooldown -= decreaseCooldown;

            if(gameManager.card_Cooldown <= 0)
            {

                GameObject cardLeft = Instantiate(cardPrefab, transform.position - new Vector3(0.25f, 0f, 0f), transform.rotation);
                Rigidbody rbLeft = cardLeft.GetComponent<Rigidbody>();
                rbLeft.velocity = Vector3.forward * 8f + Vector3.left;
                Destroy(cardLeft, gameManager.ingame_Range);

                GameObject cardNarrowLeft = Instantiate(cardPrefab, transform.position - new Vector3(0.05f, 0f, 0f), transform.rotation);
                Rigidbody rbNarrowLeft = cardNarrowLeft.GetComponent<Rigidbody>();
                rbNarrowLeft.velocity = Vector3.forward * 8f + Vector3.left;
                Destroy(cardNarrowLeft, gameManager.ingame_Range);


                GameObject cardCenterLeft = Instantiate(cardPrefab, transform.position - new Vector3(0.17f, 0f, 0f), transform.rotation);
                Rigidbody rbCenterLeft = cardCenterLeft.GetComponent<Rigidbody>();
                rbCenterLeft.velocity = Vector3.forward * 8f;
                Destroy(cardCenterLeft, gameManager.ingame_Range);


                GameObject cardCenterRight = Instantiate(cardPrefab, transform.position - new Vector3(-0.17f, 0f, 0f), transform.rotation);
                Rigidbody rbCenterRight = cardCenterRight.GetComponent<Rigidbody>();
                rbCenterRight.velocity = Vector3.forward * 8f;
                Destroy(cardCenterRight, gameManager.ingame_Range);


                GameObject cardNarrowRight = Instantiate(cardPrefab, transform.position - new Vector3(-0.05f, 0f, 0f), transform.rotation);
                Rigidbody rbNarrowRight = cardNarrowRight.GetComponent<Rigidbody>();
                rbNarrowRight.velocity = Vector3.forward * 8f + Vector3.right;
                Destroy(cardNarrowRight, gameManager.ingame_Range);


                GameObject cardRight = Instantiate(cardPrefab, transform.position - new Vector3(-0.25f, 0f, 0f), transform.rotation);
                Rigidbody rbRight = cardRight.GetComponent<Rigidbody>();
                rbRight.velocity = Vector3.forward * 8f + Vector3.right;
                Destroy(cardRight, gameManager.ingame_Range);

                

                if(gameManager.card_Cooldown <= 0)
                {
                    gameManager.card_Cooldown = gameManager.ingame_throwRate;
                }
            }
        }

    }

    void CheckSpreadDualiesBool()
    {
         if(gameManager.ingame_Dualies == true && gameManager.ingame_Spread == true && gameManager.ingame_SpreadDualies == false)
        {
            
            gameManager.ingame_SpreadDualies = true;
            gameManager.ingame_Dualies = false; 
            gameManager.ingame_Spread = false;
            
        }
    }

}
