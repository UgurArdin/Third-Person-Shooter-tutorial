using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{

   public event Action<Player> OnLocalPlayerJoined;
   
   private GameObject _gameObject;
   
   private static GameManager _instance;
   public static GameManager Instance
   {
      get
      {
         if (_instance ==null)
         {
            _instance = new GameManager();
            _instance._gameObject = new GameObject("Game_Manager");
            _instance._gameObject.AddComponent<InputManager>();
         }

         return _instance;
      }
   }


   private  InputManager _inputManager;

   public  InputManager InputManager
   {
      get
      {
         if (_inputManager == null)
         {
            _inputManager = _gameObject.GetComponent<InputManager>();
         }

         return _inputManager;
      }
   }


   private Player _localPlayer;

   public Player LocalPlayer
   {
      get
      {
         return _localPlayer;
      }
      set
      {
         _localPlayer = value;
         if (OnLocalPlayerJoined!= null)
         {
            OnLocalPlayerJoined(_localPlayer);
         }
      }
   }
}
