using System.Collections;

using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instanse;
    public static PlayerManager Instance
    {
        get
        {
            if(instanse == null)
            {
                instanse = new GameObject("PlayerManager").AddComponent<PlayerManager>();
            }
            return instanse;
        }
    }

    private Player player;
    public Player Player
    {
        get { return player; }
        set { player = value; }
    }
    private void Awake()
    {
        if(instanse == null) 
        {
            instanse = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instanse != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
