internal class Stopwatch
{
    private volatile int seconds;
    private volatile State state;

    private Thread timer;

    public Stopwatch()
    {
        Init();
    }

    private void Init()
    {
        state = State.Stopped;
        seconds = 0;

        timer = new Thread(() => {
            while (state == State.Running)
            {
                seconds++;
                Thread.Sleep(1000);
            }
        });
    }

    public TimeSpan Time
    {
        get
        {
            int ss = seconds % 60;
            int mm = (seconds / 60) % 60;
            int hh = (seconds / 3600) % 24;

            return new TimeSpan(hh, mm, ss);
        }
    }

    public State State { get => state; }

    public bool IsRunning { get => state == State.Running; }

    public void Start()
    {
        if (state == State.Suspended || state == State.Stopped)
        {
            state = State.Running;
            timer.Start();
        }
    }

    public void Suspend()
    {
        if (state == State.Running)
        {
            state = State.Suspended;
            timer.Join();
        }
    }

    public void Stop()
    {
        state = State.Stopped;
        timer.Join();
        Init();
    }

    public override string ToString()
    {
        return Time.ToString("c");
    }
}
