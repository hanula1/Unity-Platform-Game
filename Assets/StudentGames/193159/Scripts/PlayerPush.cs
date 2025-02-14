using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
namespace _193159
{
    public class PlayerPush : MonoBehaviour
    {
        public float distance = 1f;
        public LayerMask boxMask;


        // Update is called once per frame
        void Update()
        {
            Physics2D.queriesStartInColliders = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
        }
    }
}
