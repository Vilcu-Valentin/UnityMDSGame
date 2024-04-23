using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MechController : MonoBehaviour
{
    // Acesta va fi setat în inspectorul Unity la obiectul player.
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            // Atașează player-ul la mech
            player.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            // Detasează player-ul de mech
            player.transform.SetParent(null);
        }
    }
}
