﻿#region Disclaimer/Info

// ////////////////////////////////////////////////////////////////////////////////////////////////
// File:			CategoryNotFoundException.cs
// Website:		http://dexterblogengine.com/
// Authors:		http://dexterblogengine.com/About.ashx
// Created:		2012/12/01
// Last edit:	2012/12/24
// License:		GNU Library General Public License (LGPL)
// For updated news and information please visit http://dexterblogengine.com/
// Dexter is hosted to Github at https://github.com/imperugo/Dexter-Blog-Engine
// For any question contact info@dexterblogengine.com
// ////////////////////////////////////////////////////////////////////////////////////////////////
#endregion

namespace Dexter.Data.Exceptions
{
	using System;

	public class CategoryNotFoundException : ArgumentException
	{
		#region Constructors and Destructors

		public CategoryNotFoundException(string categoryId)
			: base("Unable to find the Category with the specified Id.", categoryId)
		{
		}

		public CategoryNotFoundException(string message, string paramName)
			: base(message, paramName)
		{
		}

		#endregion
	}
}