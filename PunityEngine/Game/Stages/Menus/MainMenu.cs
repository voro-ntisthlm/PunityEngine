using System;
using System.Numerics;
using Raylib_cs;
using PunityEngine;
using PunityEngine.Engine.UI;
using PunityEngine.Engine.Stage;

namespace PunityEngine.Game.Stages
{
    public class MainMenu : Stage, IStage
    {    
        public MainMenu(string _stageName){
            stageName = _stageName;
        }
        
        #region UI elements  
        static int topOffset = 20;
        
        // An array of the UI interface.
        IUI[] uiElements = {
            
            // Buttons
            // Button spacing calc: 1/10 + [previous] + 10(diff) + 40 + topOffset
            new Button(0, new Vector2(100, Raylib.GetScreenHeight()/10 +  70 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "New Game"    ),
            new Button(1, new Vector2(100, Raylib.GetScreenHeight()/10 + 120 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Saves"       ),
            new Button(2, new Vector2(100, Raylib.GetScreenHeight()/10 + 170 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "CO-OP"       ),
            new Button(3, new Vector2(100, Raylib.GetScreenHeight()/10 + 220 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Level editor"),
            new Button(4, new Vector2(100, Raylib.GetScreenHeight()/10 + 270 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Settings"    ),
            new Button(5, new Vector2(100, Raylib.GetScreenHeight()/10 + 320 + topOffset), new Vector2(250, 40), Color.WHITE, Color.BLACK, 30, "Exit"        ),
        
            // Labels
            new Label("Some Platformer", new Vector2(100, Raylib.GetScreenHeight()/10), 60, Color.WHITE)
        };
        #endregion

        // Put all UI elements in here.
        public override void DrawUI(){
            
            // Loop through all buttons, as its an array of buttons,
            // all of 'em has a draw function. 
            for (int i = 0; i < uiElements.Length; i++)
            {
                uiElements[i].Draw();
            }
        }


        // The update function is the logical loop, here all logic goes.
        public override void Update(){
            // Loop through all of the buttons, and check what button is being pressed,
            // Act accordingly.
            for (int i = 0; i < uiElements.Length; i++)
            {
                if (uiElements[i].IsClicked())
                {
                    switch (uiElements[i].ID)
                    {
                        case 0: // New Game
                            StageHandler.LoadStage(new MainGame("Game"));
                        break;
                        case 2: // Coop
                            if(StageHandler.StageExists("Coop"))
                                StageHandler.SetCurrentStage("Coop");
                            else StageHandler.LoadStage(new CoopMenu("Coop"));
                        break;
                        case 5: // Exit
                            Raylib.CloseWindow();
                            Environment.Exit(1);
                        break;
                    }   
                }    
            }
        }
    }

}
