using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts
{
    public class PinePicker : MonoBehaviour
    {
        public Camera Cam;
        public Transform Pine;
        void Update()
        {
            if (Pine == null) return; 

            Vector3 pos = Cam.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            Pine.transform.position = pos;
            if (Input.GetMouseButtonDown(0))
            {
                Pine.parent = transform;
                Pine = null;
            }
        }
    }
}
