﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MeleeEnemy : EnemyDummy
//{
//    //[SerializeField]
//    //private EnemyDummy baseEnemy;
//    private Collider2D col;

//    [SerializeField]
//    private int attackValue = 10;
//    [SerializeField]
//    private int healthValue = 30;

//    void Awake()
//    {
//        Stats = new Stats(attackValue, healthValue);
//    }

//    // Update is called once per frame
//    public void TriggerAttack()
//    {
//        col = CheckAllDirections(this.CollidablePlayers);
//        if(col != null) {
//            Attack();
//        }

//    }

//    public void Attack() {      
        
//        GameObject player = col.transform.parent.gameObject;

//        if(player.name == "Fox") {
//            IsoGame.Access.CombatManager.ReduceHealthByAttack(this.Stats.Attack, player.GetComponent<MeleeAttack>().Stats);
//        }
//        if(player.name == "Badger") {
//            IsoGame.Access.CombatManager.ReduceHealthByAttack(this.Stats.Attack, player.GetComponent<PushAttack>().Stats);
//        }
//        if (player.name == "Crow") {
//            IsoGame.Access.CombatManager.ReduceHealthByAttack(this.Stats.Attack, player.GetComponent<RangeAttack>().Stats);
//        }
//        if (player.name == "Cat") {
//            IsoGame.Access.CombatManager.ReduceHealthByAttack(this.Stats.Attack, player.GetComponent<UselessCat>().Stats);
//        }
    

//        IsoGame.Access.CombatManager.ReduceAttackByOne(this.Stats);

//    }

//    private Collider2D CheckAllDirections(LayerMask layer) {
//        if (GetCollider(IsoGame.Access.Directions.left, layer) != null) {
//            return GetCollider(IsoGame.Access.Directions.left, layer);
//        }
//        else if (GetCollider(IsoGame.Access.Directions.up, layer) != null) {
//            return GetCollider(IsoGame.Access.Directions.up, layer);
//        }
//        else if (GetCollider(IsoGame.Access.Directions.right, layer) != null) {
//            return GetCollider(IsoGame.Access.Directions.right, layer);
//        }
//        else if (GetCollider(IsoGame.Access.Directions.down, layer) != null) {
//            return GetCollider(IsoGame.Access.Directions.down, layer);
//        }
//        else return null;
//    }    

//    private Collider2D GetCollider(Vector3 direction, LayerMask layer)
//    {
//        Collider2D Collider;

//        Collider = Physics2D.OverlapPoint(gameObject.transform.position + direction, layer);

//        if (Collider != null)
//        {
//            return Collider;
//        }    

//        return Collider;
//    }
//}
