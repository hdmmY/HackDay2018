using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    static T _instance;
    public static T Instance
    {
        get
        {
            return _instance;
        }
    }
    public Singleton()
    {
        _instance = this as T;
    }
}