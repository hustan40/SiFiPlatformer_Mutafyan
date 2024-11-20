using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetPoint : MonoBehaviour
{
    public int scoreEarn;
    private InfoUpdate infoUpdate;
    private Renderer rend;
    [SerializeField] private AudioSource pickUp;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        infoUpdate = FindAnyObjectByType<InfoUpdate>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            infoUpdate.score += scoreEarn;
            infoUpdate.point.text = infoUpdate.score.ToString();
            pickUp.Play(0);
            rend.enabled = false;
            Destroy(gameObject,1);
        }
    }
}
