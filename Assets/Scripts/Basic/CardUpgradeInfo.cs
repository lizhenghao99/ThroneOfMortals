﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardUpgradeInfo", 
    menuName = "Card/Card Upgrade Info")]
public class CardUpgradeInfo : ScriptableObject
{
    public string cardName;
    public int upgradeCost;
    [TextArea]
    public string upgradeDescription;
}
