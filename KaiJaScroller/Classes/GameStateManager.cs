﻿using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GameStateManager : Game
{

    EGameState currentGameState = EGameState.MainMenu;
    EGameState prevGameState;

    IGameState gameState;

    public GameStateManager()
        : base(Settings.windowWidth, Settings.windowHeight, Settings.WINDOWTITLE, Settings.windowStyles)
    {

        handleNewGameState();
    }

    public override void update(GameTime gameTime)
    {
        InGame.pad.update();
        currentGameState = gameState.update(gameTime);

        if (currentGameState != prevGameState)
            handleNewGameState();
    }

    public override void draw(GameTime gameTime, RenderWindow window)
    {

        gameState.draw(gameTime, window);
    }

    private void handleNewGameState()
    {
        switch (currentGameState)
        {
            case EGameState.MainMenu:
                gameState = new MainMenu();
                break;

            case EGameState.InGame:
                gameState = new InGame();
                break;

            case EGameState.Credits:
                gameState = new Credits();
                break;
            case EGameState.Restart:
                gameState = new Restart();
                break;

            default:
                window.Close();
                break;
        }

        gameState.init();
        prevGameState = currentGameState;
    }
}
