using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Snake Game;

    public KeyCode Up, Down, Left, Right;
    void Update()
    {
        if (Input.GetKeyDown(Up))
        {
            Game.SwitchDirection(Snake.Directions.Up);
        }
        if (Input.GetKeyDown(Down))
        {
            Game.SwitchDirection(Snake.Directions.Down);
        }
        if (Input.GetKeyDown(Left))
        {
            Game.SwitchDirection(Snake.Directions.Left);
        }
        if (Input.GetKeyDown(Right))
        {
            Game.SwitchDirection(Snake.Directions.Right);
        }
    }



}
