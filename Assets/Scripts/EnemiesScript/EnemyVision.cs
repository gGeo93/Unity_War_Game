using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    void Update() 
    {
        transform.LookAt(GameManager.Instance.Fps.transform);
    }
}
