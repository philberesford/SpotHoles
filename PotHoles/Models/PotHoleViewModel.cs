namespace PotHoles.Models
{
	public class PotHoleViewModel
	{
		public PotHoleViewModel()
		{
			latitude = 51.520123;
			longitude = -0.118754;
			description = "Added by PB";
		}
		public double latitude { get; set; }
		public double longitude { get; set; }
		public string description { get; set; }
	}
}