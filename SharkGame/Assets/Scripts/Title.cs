using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour 
{
    public float offsetX;
    public float offsetY;

    private bool howToPlay = false;

    public float howToPlayOffsetX;
    public float howToPlayOffsetY;

    void OnGUI()
    {
        if( !howToPlay )
        {
            GUI.BeginGroup(new Rect((Screen.width - offsetX) / 2, (Screen.height - offsetY) / 2, offsetX, offsetY));
            {
                GUI.Box(new Rect(0, 0, offsetX, offsetY), "");
                if( GUILayout.Button("Start Game") )
                {
                    Application.LoadLevel("Game");
                }
                if( GUILayout.Button("How to Play") )
                {
                    howToPlay = true;
                }
            }
            GUI.EndGroup();
        }
        else
        {
            GUI.BeginGroup(new Rect((Screen.width - howToPlayOffsetX) / 2, (Screen.height - howToPlayOffsetY) / 2, howToPlayOffsetX, howToPlayOffsetY));
            {
                GUI.Box(new Rect(0, 0, howToPlayOffsetX, howToPlayOffsetY), "");
                GUILayout.Label("Press button/key on screen to accelerate.");
                GUILayout.Label("You can use keyboard pressing the key.");
                GUILayout.Label("You can also control using mouse/touch,");
                GUILayout.Label("by pressing the button on the screen.");
                GUILayout.Label("");
                GUILayout.Label("After some time without pressing, you will");
                GUILayout.Label("lose some speed.");
                GUILayout.Label("Do not let the shark get you!");
                GUILayout.Label("");
                if( GUILayout.Button("Back") )
                {
                    howToPlay = false;
                }

            }
            GUI.EndGroup();
        }
    }
}
