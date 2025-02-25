﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNeutral : EnemyDummy
{

    private bool m_isActive;
    public bool IsActive { set { m_isActive = value; } }

    [SerializeField]
    private GameObject neutralEnemyPrefab;
    private GameObject neutralEnemyState;

    void Update() {
        /*

        Maybe shouldnt be in update but somewhere where it's called regularly
        if(m_isActive) {
            if('is in Interest Range' && IsoGame.Access.CurrentEnemeis.Contains(this) == false) {
                AddToList();
            } else if('is not in Interest Range' && IsoGame.Access.CurrentEnemeis.Contains(this)) {
                RemoveFromList();
            }
        }

        */
    }

    public override void AddToList()
    {
        if(m_isActive) {
        //in case ressurection add to the remove from list
            if (m_AddedToList)
            {
                return;
            }
            IsoGame.Access.CurrentEnemeis.Add(this);
            UpdateEnemyMoveTile();
            IsoGame.Access.EnemyUIManager.UpdateEnemyUI();
            m_AddedToList = true;
            }
    }

    override public IEnumerator Move()
    {
        if (m_isActive) {

            Collider2D playerCollider = GetPlayerCollider(gameObject.transform, 1);
            if (playerCollider != null) {
                Attack(playerCollider);
                yield break;
            }

            yield return StartCoroutine(base.MoveToDir());

            playerCollider = GetPlayerCollider(gameObject.transform, 1); 
            if (playerCollider != null) {
                Attack(playerCollider);
            }

        }

    }

    override public void ReceiveDamage(int damage) {
        if (m_isActive == false) {
            m_isActive = true;
            neutralEnemyState = Instantiate(neutralEnemyPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform.parent);
            neutralEnemyState.GetComponent<EnemyNeutral>().IsActive = true;
            neutralEnemyState.GetComponent<EnemyNeutral>().AddToList();
            Destroy(this.gameObject);
        }
        else {
            stats.Health -= damage;
            anim.SetTrigger("GotHit");
            audioSources[0].Play();
            if (stats.Health <= 0) {
                Die();   
            }
        } 
    }
}