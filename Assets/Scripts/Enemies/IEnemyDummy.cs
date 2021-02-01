﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Would it be possible / better / easier / some word / if this would be an abstract Class like PlayerCombat, instead of Interface?
public abstract class IEnemyDummy : MonoBehaviour
{
    protected Stats stats;

    public Stats GetStats { get { return stats; } }

    [SerializeField]
    protected int attackValue;
    [SerializeField]
    protected int healthValue;

    protected DirectionsModel m_Directions;

    [SerializeField]
    private LayerMask collidablePlayers;    

    public abstract IEnumerator Move();

    void Awake() {
        stats = new Stats(attackValue, healthValue);
        m_Directions = IsoGame.Access.Directions;
    }
    
    abstract public void ReceiveDamage(int damage);

    protected void Attack(Collider2D playerCollider) {
        playerCollider.transform.GetComponent<PlayerCombat>().ReceiveDamage(stats.Attack);
        stats.Attack--;
    }

    protected void Die() {
        RemoveFromList();
        Destroy(this.gameObject);
    }

    protected void AddToList() {
        IsoGame.Access.CurrentEnemeis.Add(this);
        IsoGame.Access.EnemyUIManager.UpdateEnemyUI();
    }

    protected void RemoveFromList() {
        IsoGame.Access.CurrentEnemeis.Remove(this);
        IsoGame.Access.EnemyUIManager.UpdateEnemyUI();
    }

    protected Collider2D GetPlayerCollider(Transform enemy, int range) {
        Collider2D playerCollider = null;

        for(int nInd = 0; nInd < m_Directions.directionsArr.Length; nInd++) {
            playerCollider = Physics2D.OverlapPoint(enemy.position + (m_Directions.directionsArr[nInd] * range), collidablePlayers);
            if (playerCollider != null) {
                return playerCollider;
            }
        }

        return playerCollider;
    }
}