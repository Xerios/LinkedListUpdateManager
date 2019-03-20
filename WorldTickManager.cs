using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Engine;

namespace UtilityAI
{
    public class WorldTickManager
    {
        private static WorldTickManager _instance;

        public static WorldTickManager Instance {
            get {
                if (_instance == null) {
                    _instance = new WorldTickManager();
                }
                return _instance;
            }
        }

        private UpdateManager realtime;
        private UpdateManager[] tick;

        public void Init(int tickcapacity = 5){
            realtime = new UpdateManager();

            tick = new UpdateManager[tickcapacity];
            for (int i = 0; i < tickcapacity; i++)
            {
                tick[i] = new UpdateManager();
            }
        }

        public WorldTickManager AddRealtime(string group, Action function){
            realtime.Add(group, function);
            return this;
        }

        public WorldTickManager AddTick(int id, string group, Action function){ 
            tick[id].Add(group, function);
            return this;
        }


        public WorldTickManager RemoveRealtime(string group, Action function){
            realtime.Remove(group, function);
            return this;
        }
        public WorldTickManager RemoveTick(int id, string group, Action function){ 
            tick[id].Remove(group, function);
            return this;
        }

        public void UpdateRealtime(){
            realtime.Update();
        }

        public void UpdateTick(int id){
            tick[id].Update();
        }
    }
}