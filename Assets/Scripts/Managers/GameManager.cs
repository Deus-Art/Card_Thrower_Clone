using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public UiManager uiManager;
    public float ingame_throwRate, ingame_Range, card_Cooldown;
    public bool isDragging, isThrowing, ingame_Dualies, ingame_Spread, ingame_SpreadDualies;
    
    
    void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnStart, OnStart);
        EventManager.AddHandler(GameEvent.OnSingleThrow, OnSingleThrow);
        EventManager.AddHandler(GameEvent.OnSpreadWithDualies, OnSpreadWithDualies);
        EventManager.AddHandler(GameEvent.OnInGameDualies, OnInGameDualies);
        EventManager.AddHandler(GameEvent.OnInGameSpread, OnInGameSpread);


        EventManager.AddHandler(GameEvent.OnInGameThrowRate, OnInGameThrowRate);
        EventManager.AddHandler(GameEvent.OnThrowRateMinus, OnThrowRateMinus);
        
        EventManager.AddHandler(GameEvent.OnInGameRange, OnInGameRange);
        EventManager.AddHandler(GameEvent.OnRangeMinus, OnRangeMinus);

        EventManager.AddHandler(GameEvent.OnInGameMoney, OnInGameMoney);

        EventManager.AddHandler(GameEvent.OnLose, OnLose);
        EventManager.AddHandler(GameEvent.OnWin, OnWin);

        

    }

    void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnStart, OnStart);
        EventManager.RemoveHandler(GameEvent.OnSingleThrow, OnSingleThrow);
        EventManager.RemoveHandler(GameEvent.OnSpreadWithDualies, OnSpreadWithDualies);
        EventManager.RemoveHandler(GameEvent.OnInGameDualies, OnInGameDualies);
        EventManager.RemoveHandler(GameEvent.OnInGameSpread, OnInGameSpread);


        EventManager.RemoveHandler(GameEvent.OnInGameThrowRate, OnInGameThrowRate);
        EventManager.RemoveHandler(GameEvent.OnThrowRateMinus, OnThrowRateMinus);
        
        EventManager.RemoveHandler(GameEvent.OnInGameRange, OnInGameRange);
        EventManager.RemoveHandler(GameEvent.OnRangeMinus, OnRangeMinus);

        EventManager.RemoveHandler(GameEvent.OnInGameMoney, OnInGameMoney);

        EventManager.RemoveHandler(GameEvent.OnLose, OnLose);
        EventManager.RemoveHandler(GameEvent.OnWin, OnWin);

    }


    void OnStart()
    {
        isDragging = true;
        uiManager.powerUps.SetActive(false);
    }
    
    void OnSingleThrow()
    {
        if(ingame_Dualies == false && ingame_Spread == false && ingame_SpreadDualies == false)
        {
            isThrowing = true;
        }
    }

    void OnInGameDualies()
    {
        isThrowing = false;
        ingame_Dualies = true;
    }

    void OnInGameSpread()
    {
        isThrowing = false;
        ingame_Spread = true;
    }

    void OnSpreadWithDualies()
    {
        if(ingame_Dualies == true && ingame_Spread == true)
        {
            ingame_SpreadDualies = true;
        }
    }
    // void OnThrowRate() //BASE THROW RATE
    // {
    //     ingame_throwRate = gameData.throwRate_value;
    // }

    void OnInGameThrowRate() //IN-GAME TEMPORARY THROW RATE
    {
        ingame_throwRate -= 0.25f;
    }

    void OnThrowRateMinus()
    {
        ingame_throwRate += 0.25f;
    }

    void OnInGameRange()
    {
        ingame_Range += 0.25f;
    }

    void OnRangeMinus()
    {
        ingame_Range -= 0.25f;
    }

    void OnInGameMoney()
    {
        gameData.totalMoney += 10f;
    }

    void OnLose()
    {
        isDragging = false;
        isThrowing = false;
        ingame_Dualies = false;
        ingame_Spread = false;
        ingame_SpreadDualies = false;
        uiManager.losePanel.SetActive(true);
    }

    void OnWin()
    {
        isDragging = false;
        isThrowing = false;
        ingame_Dualies = false;
        ingame_Spread = false;
        ingame_SpreadDualies = false;
        uiManager.winPanel.SetActive(true);
    }

    


    void Awake()
    {
        ingame_throwRate = gameData.throwRate_value;
        ingame_Range = gameData.range_value;
        ingame_Dualies = false;
        ingame_Spread = false;
        card_Cooldown = ingame_throwRate;
    }
}
