using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace _193159
{
    public class Dialogue : MonoBehaviour
    {
        public Dictionary<string, string[]> dialogue = new Dictionary<string, string[]>();

        private void Start()
        {
            //Devil
            dialogue.Add("Devil", new string[] {
                "Witam gor�co w piekle,",
                "Wy�a� z cienia i poka� si� przede mn�!",
                "Jak si� nazywasz m�czenniku?",
                "O bardzo mi mi�o :)",
                "Ja jestem Diabe� ale to widz�, �e ju� wiedzia�e�...",
                "Zapraszam na pocz�stunek"
            });

            dialogue.Add("PlayerChoice1", new string[]
            {
                "",
                "",
                "",
                "..."
            });

            dialogue.Add("PlayerChoice2", new string[]
            {
                "",
                "",
                "",
                "Lisak panie Diable"
            });
        }
    
    }
}
