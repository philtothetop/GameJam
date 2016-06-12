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
        public Bounds pineBounds;


        void Start()
        {
            pineBounds.SetMinMax(new Vector3(0.5f, 14.5f), new Vector3(59.5f, 89.5f));
        }

        void Update()
        {
            if (Pine == null) return;
            
            Vector3 pos = Cam.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            if (!pineBounds.Contains(pos))
            {
                Pine.GetComponent<SpriteRenderer>().enabled = false;
                return;
            }
            else
            {
                Pine.GetComponent<SpriteRenderer>().enabled = true;
            }
            Pine.transform.position = pos;
           
            if (Input.GetMouseButtonDown(0) && pineBounds.Contains(pos))
            {
                Pine.parent = transform;
                Pine = null;
            }
            
        }
        
    }
}
