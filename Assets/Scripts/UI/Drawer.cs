﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using DG.Tweening;

public class Drawer : MonoBehaviour
{
    [SerializeField] public Card.Owner owner;

    private PlayerController player;
    private HandManager hand;
    private Healthbar healthbar;
    private ResourceDisplay resource;
    private DiscardButton discardButton;
    private HeadButton headButton;
    private PlayerHealth health;

    private CanvasGroup group;

    private void Awake()
    {
        player = FindObjectsOfType<PlayerController>()
                        .Where(p => p.gameObject.name == owner.ToString())
                        .FirstOrDefault();
        hand = GetComponentInChildren<HandManager>();
        healthbar = GetComponentInChildren<Healthbar>();
        resource = GetComponentInChildren<ResourceDisplay>();
        discardButton = GetComponentInChildren<DiscardButton>();
        headButton = GetComponentInChildren<HeadButton>();
        health = player.GetComponent<PlayerHealth>();

        group = gameObject.GetComponent<CanvasGroup>();

        hand.player = player;
        healthbar.player = player;
        resource.player = player;
        discardButton.owner = owner;
        headButton.owner = owner;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        discardButton.interactable = 
            !(CardPlayer.Instance.isPlayingCard 
            || player.isCasting );

        headButton.interactable =
            !(CardPlayer.Instance.isPlayingCard);

        if (health.isDead)
        {
            group.interactable = false;
            group.DOFade(0.5f, 0.3f).SetEase(Ease.OutQuint);
        }
    }
}
