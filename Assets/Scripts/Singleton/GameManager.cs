using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region  Public Variables

    public GameObject Player => _player ?? (_player = GameObject.FindGameObjectWithTag ("Player"));

    #endregion


    #region Private Variables and Methods 

    private GameObject _player;

    #endregion
}