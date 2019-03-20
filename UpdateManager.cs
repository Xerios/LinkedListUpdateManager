using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Engine;

namespace UtilityAI
{
    public class UpdateManager
    {
        private SortedDictionary<string, LinkedList<Action>> updates = new SortedDictionary<string, LinkedList<Action>>();

        public void Add(string group, Action function){
            
            LinkedList<Action> list;
            updates.TryGetValue(group, out list);

            if (list == null) {
                list = new LinkedList<Action>();
                updates[group] = list;
            }

            list.AddLast(function);
        }

        public void Remove(string group, Action function){
            
            LinkedList<Action> list;
            updates.TryGetValue(group, out list);

            if (list != null) {
                list.Remove(function);
            }
        }

        public void Update(){
            foreach(var updateList in updates){
                var node = updateList.Value.First;
                
                UnityEngine.Profiling.Profiler.BeginSample(updateList.Key);

                while (node != null) {
                    node.Value.Invoke();
                    node = node.Next;
                }
                UnityEngine.Profiling.Profiler.EndSample();
            }
        }

        public bool Contains(string group, Action function)
        {
            LinkedList<Action> list;
            updates.TryGetValue(group, out list);

            if (list == null) return false;
        
            return list.Contains(function);
        }
    }
}