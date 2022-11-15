using System;
using System.Collections.Generic;

public enum GameEvent
{
    OnStart, //bool
    OnInGameDualies, //bool
    OnInGameSpread, //bool
    OnSpreadWithDualies, //bool
    OnSingleThrow, //float
    //OnThrowRate, //float
    OnInGameRange, //float
    OnInGameThrowRate, //float
    OnRangeMinus, //float
    OnThrowRateMinus, //float
    OnInGameMoney,  //float
    OnLose,
    OnWin
}
public static class EventManager
{   
    private static Dictionary<GameEvent, Action> eventTable = new Dictionary<GameEvent, Action>();

    public static void AddHandler(GameEvent gameEvent, Action action)
    {

        if(!eventTable.ContainsKey(gameEvent))
            eventTable[gameEvent] = action;
        
        else
            eventTable[gameEvent] += action;
        
    }
    
    public static void RemoveHandler(GameEvent gameEvent, Action action)
    {

        if(eventTable[gameEvent] != null)
            eventTable[gameEvent] -= action;

        if(eventTable[gameEvent] == null)
            eventTable.Remove(gameEvent);
        
    }

    public static void Broadcast(GameEvent gameEvent)
    {

        if(eventTable[gameEvent] != null)
            eventTable[gameEvent]();

    }
}
