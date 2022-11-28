using FirstGearGames.SmoothCameraShaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerTest : MonoBehaviour
{
    public ShakeData MyShakeData;
    

    private void Start()
    {
        CameraShakerHandler.Shake(MyShakeData);
    }

  
}
