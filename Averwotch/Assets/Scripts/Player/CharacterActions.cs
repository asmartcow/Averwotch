using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CharacterActions : PlayerActionSet
{
    public PlayerAction left;
    public PlayerAction right;
    public PlayerAction forward;
    public PlayerAction backward;
    public PlayerAction jump;
    public PlayerOneAxisAction moveLR;
    public PlayerOneAxisAction moveFB;

    public CharacterActions()
    {
        left = CreatePlayerAction("Move Left");
        right = CreatePlayerAction("Move Right");
        forward = CreatePlayerAction("Move Forward");
        backward = CreatePlayerAction("Move Backward");
        jump = CreatePlayerAction("Jump");
        moveLR = CreateOneAxisPlayerAction(left, right);
        moveFB = CreateOneAxisPlayerAction(forward, backward);
    }
}
