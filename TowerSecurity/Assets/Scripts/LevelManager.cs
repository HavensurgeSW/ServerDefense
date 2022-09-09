using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]EnemyHandler enemyHandler;
    [SerializeField]Location[] locations;

    public Location[] LOCATIONS => locations;


}
