﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrator : MonoBehaviour
{

    public void Vibrate(int vibration)
    {
        Vibration.Vibrate(vibration);
    }
}
