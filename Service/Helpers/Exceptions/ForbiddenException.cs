﻿using System;
namespace Service.Helpers.Exceptions
{
	public class ForbiddenException:Exception
	{
		public ForbiddenException(string message) : base(message) { }
	}
}

