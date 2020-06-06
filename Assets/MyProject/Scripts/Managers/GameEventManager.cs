using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventManager : Singleton<GameEventManager>
{
    public UnityAction<Fire> onPlayerNearFire;
    public UnityAction onPlayerExitFire;
    public UnityAction onCompletedLevel;

    public void PlayerNearFire(Fire fire)
    {
        onPlayerNearFire?.Invoke(fire);
    }

    public void PlayerExitFire()
    {
        onPlayerExitFire?.Invoke();
    }

    public void CompleteLevel()
    {
        onCompletedLevel?.Invoke();
    }
}
