using UnityEngine;
using System.Collections.Generic;

public enum Action
{
    None,
    Crouch,
    Sprint,
    Jump,
    Quit
}

[System.Serializable]
public class GameKey : System.Object
{
    public KeyCode key;
    public Action action;
}

public class KeyManager : MonoBehaviour
{

    public static KeyManager main;

    void Awake()
    {
        main = this;
    }

    [SerializeField]
    private List<GameKey> gameKeys = new List<GameKey>();

    public bool GetKeyDown(Action action)
    {
        foreach (KeyCode kc in GetKeyCode(action))
        {
            if (Input.GetKeyDown(kc))
            {
                return true;
            }
        }
        return false;
    }

    public bool GetKeyUp(Action action)
    {
        foreach (KeyCode kc in GetKeyCode(action))
        {
            if (Input.GetKeyUp(kc))
            {
                return true;
            }
        }

        return false;
    }

    public bool GetKey(Action action)
    {
        foreach (KeyCode kc in GetKeyCode(action))
        {
            if (Input.GetKey(kc))
            {
                return true;
            }
        }
        return false;
    }

    public List<KeyCode> GetKeyCode(Action action)
    {
        List<KeyCode> keys = new List<KeyCode>();
        foreach (GameKey gameKey in gameKeys)
        {
            if (gameKey.action == action)
            {
                keys.Add(gameKey.key);
            }
        }
        return keys;
    }

    public string GetKeyString(Action action)
    {
        foreach (GameKey gameKey in gameKeys)
        {
            if (gameKey.action == action)
            {
                string keyString = gameKey.key.ToString();
                if (gameKey.key == KeyCode.Return)
                {
                    keyString = "Enter";
                }
                else if (gameKey.key == KeyCode.RightControl)
                {
                    keyString = "Right Ctrl";
                }
                return keyString;
            }
        }
        return "";
    }
}
