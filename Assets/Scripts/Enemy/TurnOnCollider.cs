using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCollider : MonoBehaviour
{
    [SerializeField]private BoxCollider2D coll;
    public void TurnOnTrigger()
    {
        coll.gameObject.SetActive(true);
    }
    public void TurnOffTrigger()
    {
        coll.gameObject.SetActive(false);
    }
}
