using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts
{
    class VoidMaw : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            GameManager._currentBalls.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
