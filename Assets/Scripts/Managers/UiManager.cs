using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public GameData gameData;
    public GameManager gameManager;
    //public BoxCollision boxCollision;

    public TextMeshProUGUI rangeLevel, throwRateLevel, incomeLevel, totalMoney,
    range_cost, throwRate_cost, income_cost;
    public Button rangeInteractable, throwRateInteractable, incomeInteractable;
    public GameObject losePanel, winPanel, powerUps;

    //public List<TextMeshProUGUI> ropesOnBoxList = new List<TextMeshProUGUI>();

    // void ListOfRopes()
    // {
    //     foreach (var item in ropesOnBoxList)
    //     {
    //         item.text = "" + boxCollision.ropesOnBox.ToString();
    //     }
    // }

    void Update() 
    {
        LevelsText();
        ControlInteractable();
        //ListOfRopes();
    }

    void LevelsText()
    {
        rangeLevel.text = "lvl " + gameData.range_level.ToString();
        throwRateLevel.text = "lvl " + gameData.throwRate_level.ToString();
        incomeLevel.text = "lvl " + gameData.income_level.ToString();
        totalMoney.text = "" + gameData.totalMoney.ToString();

        range_cost.text = "" + gameData.range_base.ToString();
        throwRate_cost.text = "" + gameData.throwRate_base.ToString();
        income_cost.text = "" + gameData.income_base.ToString();

        //ropesOnBox.text = "" + boxCollision.ropesOnBox.ToString();
    }


    public void RangeButton()
    {
        if(gameData.totalMoney >= gameData.range_base)
        {
            gameData.totalMoney -= gameData.range_base;
            gameData.range_level += 1;
            gameData.range_base += gameData.range_increase;
            gameData.range_value += 0.25f;
            gameManager.ingame_Range = gameData.range_value;
        }
    }

    public void ThrowRateButton()
    {
        if(gameData.totalMoney >= gameData.throwRate_base)
        {
            gameData.totalMoney -= gameData.throwRate_base;
            gameData.throwRate_level += 1;
            gameData.throwRate_base += gameData.throwRate_increase;
            gameData.throwRate_value -= 0.25f;
            gameManager.ingame_throwRate = gameData.throwRate_value;

        }
    }

    public void IncomeButton()
    {
        if(gameData.totalMoney >= gameData.income_base)
        {
            gameData.totalMoney -= gameData.income_base;
            gameData.income_level += 1;
            gameData.income_base += gameData.income_increase;
            gameData.income_value += 10;
        }
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("Level 2");
    }

    void ControlInteractable()
    {
        if(gameData.totalMoney < gameData.range_base)
        {
            rangeInteractable.interactable = false;
        }
        else if(gameData.totalMoney >= gameData.range_base)
        {
            rangeInteractable.interactable = true;
        }

        if(gameData.totalMoney < gameData.throwRate_base)
        {
            throwRateInteractable.interactable = false;
        }
        else if(gameData.totalMoney >= gameData.throwRate_base)
        {
            throwRateInteractable.interactable = true;
        }

        if(gameData.totalMoney < gameData.income_base)
        {
            incomeInteractable.interactable = false;
        }
        else if(gameData.totalMoney >= gameData.income_base)
        {
            incomeInteractable.interactable = true;
        }
    }
}
