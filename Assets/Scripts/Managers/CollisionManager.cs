using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class CollisionManager : MonoBehaviour
{
    //ObiRope obiRope;
    public GameObject moneyParticle, confetti;
    
    void OnTriggerEnter(Collider other) 
    {
        switch(other.tag)
        {
            case "Dualies":
            EventManager.Broadcast(GameEvent.OnInGameDualies);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;

            case "Spread":
            EventManager.Broadcast(GameEvent.OnInGameSpread);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;
        #region  Throwrates
            case "TRatePlusOne":
            EventManager.Broadcast(GameEvent.OnInGameThrowRate);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;

            case "TRatePlusTwo":
            EventManager.Broadcast(GameEvent.OnInGameThrowRate);
            EventManager.Broadcast(GameEvent.OnInGameThrowRate);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;

            case "TRatePlusThree":
            EventManager.Broadcast(GameEvent.OnInGameThrowRate);
            EventManager.Broadcast(GameEvent.OnInGameThrowRate);
            EventManager.Broadcast(GameEvent.OnInGameThrowRate);
            MeshOff(other.gameObject);
            //other.GetComponent<MeshRenderer>().material.color = Color.black;
            //other.GetComponent<MeshRenderer>().materials[2].color = Color.black;
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;
            
            case "TRateMinusOne":
            EventManager.Broadcast(GameEvent.OnThrowRateMinus);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;

            case "TRateMinusTwo":
            EventManager.Broadcast(GameEvent.OnThrowRateMinus);
            EventManager.Broadcast(GameEvent.OnThrowRateMinus);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;

            case "TRateMinusThree":
            EventManager.Broadcast(GameEvent.OnThrowRateMinus);
            EventManager.Broadcast(GameEvent.OnThrowRateMinus);
            EventManager.Broadcast(GameEvent.OnThrowRateMinus);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;
        #endregion

        #region  Ranges
            case "RangePlusOne":
            EventManager.Broadcast(GameEvent.OnInGameRange);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;

            case "RangePlusTwo":
            EventManager.Broadcast(GameEvent.OnInGameRange);
            EventManager.Broadcast(GameEvent.OnInGameRange);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;

            case "RangePlusThree":
            EventManager.Broadcast(GameEvent.OnInGameRange);
            EventManager.Broadcast(GameEvent.OnInGameRange);
            EventManager.Broadcast(GameEvent.OnInGameRange);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;

            case "RangeMinusOne":
            EventManager.Broadcast(GameEvent.OnRangeMinus);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;

            case "RangeMinusTwo":
            EventManager.Broadcast(GameEvent.OnRangeMinus);
            EventManager.Broadcast(GameEvent.OnRangeMinus);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;

            case "RangeMinusThree":
            EventManager.Broadcast(GameEvent.OnRangeMinus);
            EventManager.Broadcast(GameEvent.OnRangeMinus);
            EventManager.Broadcast(GameEvent.OnRangeMinus);
            MeshOff(other.gameObject);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            break;
        #endregion

            case "Money":
            EventManager.Broadcast(GameEvent.OnInGameMoney);
            Instantiate(moneyParticle, transform.position, transform.rotation);
            SoundManager.PlaySound(SoundManager.Sound.enterGate);
            other.GetComponent<Collider>().enabled = false;
            Destroy(other.gameObject);
            break;

            case "BoxInGame":
            EventManager.Broadcast(GameEvent.OnLose);
            break;

            case "BoxInFinish":
            EventManager.Broadcast(GameEvent.OnWin);
            Instantiate(confetti, transform.position, transform.rotation);
            SoundManager.PlaySound(SoundManager.Sound.wonGame);
            break;
        
        }
    }

   

    void MeshOff(GameObject other)
    {
        other.GetComponent<MeshRenderer>().materials[0].color = Color.black;
        other.GetComponent<MeshRenderer>().materials[1].color = Color.gray;
        other.GetComponent<MeshRenderer>().materials[2].color = Color.black;
    }
}
