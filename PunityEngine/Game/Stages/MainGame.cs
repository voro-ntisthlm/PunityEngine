using System;
using Raylib_cs;
using PunityEngine;
using PunityEngine.Game.Entities;
using PunityEngine.Engine.Stage;

namespace PunityEngine.Game.Stages
{
    public class MainGame : Stage, IStage
    {
        public MainGame(string _stageName){
            stageName = _stageName;
        }
        
        Player player = new Player();       

        public override void DrawGame(){
            player.Draw();
        }

        public override void Update(){
            player.Update();
        }
    }
}
