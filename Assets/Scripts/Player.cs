using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{
    private InputManager _inputManager;
    private MoveController _moveController;

    public MoveController MoveController
    {
        get
        {
            if (_moveController ==null)
            {
                _moveController = GetComponent<MoveController>();
            }

            return _moveController;
        }
    }
    
    [System.Serializable]
    public class MouseInput
    {
        public Vector2 damping;
        public Vector2 sensivitiy;
    }
    [SerializeField] private MouseInput mouseControl;
    [SerializeField] private float speed;
    
    
    void Awake()
    {
        _inputManager = GameManager.Instance.InputManager;
        GameManager.Instance.LocalPlayer = this;
    }
    
    void Update()
    {
        Vector2 direction = new Vector2(_inputManager.horizontal*speed, _inputManager.vertical*speed);
        MoveController.Move(direction);
    }
}
