using System.Collections.Generic;

namespace DKOctoberTablet.Models
{
	public class ScheduleItem
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Leader { get; set; }
		public List<DayScheduleItem> Days { get; set; } = new List<DayScheduleItem>();
	}
}
