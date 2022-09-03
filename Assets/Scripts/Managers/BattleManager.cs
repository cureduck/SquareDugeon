using System;
using System.Collections.Generic;
using Main;
using UI;
using UnityEngine.UI;

namespace Managers
{
    public class BattleManager : Singleton<BattleManager>
    {

        public LinkedList<Func<Attack, Attack>>  PlayerAttackModifier;
        public Func<Attack,Attack> EnemyAttackModifier;

        public Func<Attack,Attack> PlayerDamagedModifier;
        public Func<Attack,Attack> EnemyDamagedModifier;
        
        
        
        public void Deal()
        {
            var player = GameManager.Instance.GamePlayerData;
            var enemy = EnemyStatusUI.Instance.Fighter;

            var origin_atk = player.Attack();
            var final_atk = Chain(origin_atk, PlayerAttackModifier);
            
            
            
            enemy?.Damaged(player.Attack());

            if (enemy != null)
            {
                player.Damaged(enemy.Attack());
            }
        }

        private void Start()
        {
            PlayerAttackModifier = new LinkedList<Func<Attack, Attack>>();
        }


        public T Chain<T>(T input, LinkedList<Func<T, T>> funcs)
        {
            
            foreach (var f in funcs)
            {
                input = f(input);
            }

            return input;
        }
        
    }
}