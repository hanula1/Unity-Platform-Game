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
                "Witam gor¹co w piekle,",
                "Wy³aŸ z cienia i poka¿ siê przede mn¹!",
                "Jak siê nazywasz mêczenniku?",
                "O bardzo mi mi³o :)",
                "Ja jestem Diabe³ ale to widzê, ¿e ju¿ wiedzia³eœ...",
                "Zapraszam na poczêstunek"
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
