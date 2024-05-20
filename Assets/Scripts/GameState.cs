using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateGame
{
    Playing,
    End,
    OpenStore,
}
public static class GameState
{
    public static StateGame stateGame;
}
