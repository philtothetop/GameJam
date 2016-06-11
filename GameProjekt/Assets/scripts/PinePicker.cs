using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts
{
    class PinePicker : MonoBehaviour
    {
        public Transform Pine;
        void Update()
        {
            if (Pine == null) return; 

            Pine.transform.position = UnityEngine.Input.mousePosition;
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                Pine.parent = transform;
                Pine = null;
            }
        }
    }
}
