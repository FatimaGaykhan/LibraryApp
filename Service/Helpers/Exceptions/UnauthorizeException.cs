using System;
namespace Service.Helpers.Exceptions
{
	public class UnauthorizeException:Exception
	{
		public UnauthorizeException(string message) : base(message) { }

	}
}

