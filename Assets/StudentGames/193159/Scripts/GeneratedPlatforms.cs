using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace _193159
{
    public class GeneratedPlatforms : MonoBehaviour
    {
        [SerializeField] public GameObject platformPrefab;
        public const int PLATFORMS_NUM = 3; //liczba generowanych platform
        private GameObject[] platforms;
        private Vector3[] startingPositions;

        public float amplitude = 3f;    //amplituda sin
        public float frequency = 1f;    //czêstotliwoœæ sin
        public float speed = 2f;
        private float xBorder = 50f;

        private void Awake()
        {
            platforms = new GameObject[PLATFORMS_NUM];
            startingPositions = new Vector3[PLATFORMS_NUM];
        }
        void Start()
        {
            for (int i = 0; i < PLATFORMS_NUM; i++)
            {
                startingPositions[i] = this.transform.position;
                startingPositions[i].x += i;
                platforms[i] = Instantiate(platformPrefab, startingPositions[i], Quaternion.identity);
            }
        }

        void Update()
        {
            for (int i = 0; i < PLATFORMS_NUM; i++)
            {
                float x = platforms[i].transform.position.x;
                x += Time.deltaTime * speed;
                if (x >= xBorder + i)
                {
                    x = startingPositions[i].x;
                }
                float y = amplitude * Mathf.Sin(frequency * x);
                float z = 0f;

                platforms[i].transform.position = new Vector3(x, y, z);
            }
        }


    }
}