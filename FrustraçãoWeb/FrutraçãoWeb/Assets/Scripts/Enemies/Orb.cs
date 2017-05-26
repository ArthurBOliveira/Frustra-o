using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour
{
    public GameObject laser;

    public void OnDestroy()
    {
        Destroy(laser);
    }
}
