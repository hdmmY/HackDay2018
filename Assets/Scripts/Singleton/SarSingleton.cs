using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SarSingleton<T> : MonoBehaviour where T:SarSingleton<T> {
    public static T Instance;
    public  SarSingleton()
    {
        Instance = this as T;
    }
}
