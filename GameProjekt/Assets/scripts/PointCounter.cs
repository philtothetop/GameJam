﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts
{
    public class PointCounter : MonoBehaviour
    {
        private GoalManager manager;

        void Awake()
        {
            manager = GetComponent<GoalManager>();
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (manager.player == 1) GameManager.Player1Points++;
            else GameManager.Player2Points++;
        }
    }
}
