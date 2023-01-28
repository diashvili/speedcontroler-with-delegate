namespace G15;
internal class SpeedController
{
    Action<int> Speedhandler;

    private int _currentSpeed;

	public SpeedController(Action<int> speedHandler = null)
	{
		Speedhandler = speedHandler;
		MaxSpeed = Random.Shared.Next(200, 300);
	}

	public int MaxSpeed { get; private init; }

	public int CurrentSpeed
	{
		get
		{
			return _currentSpeed;
		}
		set
		{
			if (value > MaxSpeed)
			{
				if (Speedhandler != null)
				{
					Speedhandler(value - MaxSpeed);
				}
				else
				{
					Warning();
				}
			}
			_currentSpeed = value;
		}
	}

	private void Warning()
	{
		Console.WriteLine("Please Slow Down!");
	}
}