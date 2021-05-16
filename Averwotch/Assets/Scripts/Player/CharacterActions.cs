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
    public PlayerAction use;
    public PlayerAction drop;
    public PlayerAction wep1;
    public PlayerAction wep2;
    public PlayerAction wep3;
    public PlayerOneAxisAction moveLR;
    public PlayerOneAxisAction moveFB;
    public PlayerAction quicksave;
    public PlayerAction quickload;
    public PlayerAction nextWeapon;
    public PlayerAction prevWeapon;

    public CharacterActions()
    {
        left = CreatePlayerAction("Move Left");
        right = CreatePlayerAction("Move Right");
        forward = CreatePlayerAction("Move Forward");
        backward = CreatePlayerAction("Move Backward");
        jump = CreatePlayerAction("Jump");
        use = CreatePlayerAction("Use");
        drop = CreatePlayerAction("Drop");
        wep1 = CreatePlayerAction("Wep1");
        wep2 = CreatePlayerAction("Wep2");
        wep3 = CreatePlayerAction("Wep3");
        moveLR = CreateOneAxisPlayerAction(left, right);
        moveFB = CreateOneAxisPlayerAction(forward, backward);
        quicksave = CreatePlayerAction("Quick Save");
        quickload = CreatePlayerAction("Quick Load");
        nextWeapon = CreatePlayerAction("Next Weapon");
        prevWeapon = CreatePlayerAction("Previous Weapon");
    }
}
