using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;        // The player's score.
        public static int ammunition;

        public GameObject TextAmmo;
        Text text, textAmmunition;                      // Reference to the Text component.


        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();
            textAmmunition = TextAmmo.GetComponent<Text>();
            // Reset the score.
            score = 0;
            ammunition = 0;
        }


        void Update ()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
            text.text = "Врагов убито: " + score;
            textAmmunition.text = "" + ammunition;
        }
    }
}