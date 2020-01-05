using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScriptableTile))]
public class TileController : MonoBehaviour{
    private Vector3 _targetPosition {get; set;}
    private float _startingDistance {get; set;}
    private float _distanceCheck {get; set;}
    [SerializeField] private float _SPEED = 1f;

    [SerializeField] private Material _HOVER_MATERIAL;
    [SerializeField] private Material _STANDARD_MATERIAL;
    [SerializeField] private Material _material;

    private void Start() {
        _targetPosition = transform.position;
    }

    private void Update() {
        if(transform.position != _targetPosition){
            // Moves the object to target position
            float moveSpeed = _SPEED;
            if(_startingDistance > _distanceCheck){
                moveSpeed *= _startingDistance;
            } 
            transform.position = Vector3.MoveTowards(
                transform.position, 
                _targetPosition,
                Time.deltaTime * moveSpeed 
            );
        }
    }

    public void SetTarget(Vector3 target, float spacer = .5f){
        _distanceCheck = spacer;
        _startingDistance = Vector3.Distance(target, transform.position);
        target.y = 0.125f;
        _targetPosition = target;
    }
}
