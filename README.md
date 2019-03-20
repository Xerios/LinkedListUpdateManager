# Update and Ticked update manager for Unity

A simple fast LinkedList-based update manager.
Comes from an old project, thought this would be handy for someone else.

## Usage

### Initialize

```
WorldTickManager.Instance.Init(5);
```

### Add actions to updatemanager

```
WorldTickManager.Instance
    .AddTick(0 ,"1.0:Mind.FadeMemory", mind.FadeMemory)
    .AddTick(0 ,"1.1:Mind.ExpireFails", mind.ExpireFails)
    .AddTick(1 ,"2.0:Mind.CalculateDecisions", mind.CalculateDecisions)
    .AddTick(2, "3:SequenceTick", seqPlayer.Tick)
    .AddTick(3 ,"4:Tick", Tick)
    .AddTick(4 ,"5:BroadcastTick", BroadcastTick)
    .AddRealtime("1:Pathfind", FastPathfind)
    .AddRealtime("2:FastUpdate", FastUpdate)
    .AddRealtime("3:Animate", FastAnimateUpdate)
    .AddRealtime("4:Emotions", Emotions.FastUpdate);
```

### Updating

```
var mgr =  WorldTickManager.Instance;
mgr.UpdateRealtime();

// These can be wherever you want
// In my old project it was used with InvokeRepeating("MasterTick", 0.1f, 0.2f);
mgr.UpdateTick(0);
mgr.UpdateTick(1);
mgr.UpdateTick(2);
mgr.UpdateTick(3);
mgr.UpdateTick(4);
```
