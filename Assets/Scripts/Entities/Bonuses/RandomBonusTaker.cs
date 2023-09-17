using System;
using System.Linq;
using System.Reflection;

public static class RandomBonusTaker
{
	private static Type[] _bonuses;

	static RandomBonusTaker()
	{
		_bonuses = Assembly.GetAssembly(typeof(RandomBonusTaker))
			.GetTypes()
			.Where(t => typeof(Bonus).IsAssignableFrom(t) && !t.IsAbstract)
			.ToArray();
	}

	public static Type GetRandomBonusType()
	{
		int randomIndex = new Random().Next(0, _bonuses.Length);

		return _bonuses[randomIndex];
	}
}
