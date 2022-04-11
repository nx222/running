var smartphone = new Smartphone();
smartphone.BeginRun();
smartphone.FinishRun();

var watches = new Watches();
watches.BeginRun();
watches.FinishRun();

var watchesmap = new WatchesMap(watches);
watchesmap.BeginRun();
watchesmap.FinishRun();
