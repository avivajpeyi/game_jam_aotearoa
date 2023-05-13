using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimerParameters
{
    public float Timer2DStartTime = 5f;
    public float Timer3DStartTime = 10f;
    public float TimerMaxTime = 12f;
}

[System.Serializable]
public class PickupParameters
{
    public float Timer2DPickupMultiplyer = 1f;
    public float Timer3DPickupMultiplyer = 1f;
}

[System.Serializable]
public class ScoreParamters
{
    public float ScoreMultiplyer = 1f;
}

[System.Serializable]
public class PlayerParameters
{
    public float PramSpeed = 1f;
    public float JumpHeightMultiplyer = 1f;
}
public class ParameterController : MonoBehaviour
{
    public TimerParameters TimerParameters;
    public PickupParameters PickupParameters;
    public ScoreParamters ScoreParamters;
    public PlayerParameters PlayerParameters;
}
