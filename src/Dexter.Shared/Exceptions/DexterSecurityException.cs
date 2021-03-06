﻿#region Disclaimer/Info

// ////////////////////////////////////////////////////////////////////////////////////////////////
// File:			DexterSecurityException.cs
// Website:		http://dexterblogengine.com/
// Authors:		http://dexterblogengine.com/aboutus
// Created:		2013/03/14
// Last edit:	2013/03/15
// License:		New BSD License (BSD)
// For updated news and information please visit http://dexterblogengine.com/
// Dexter is hosted to Github at https://github.com/imperugo/Dexter-Blog-Engine
// For any question contact info@dexterblogengine.com
// ////////////////////////////////////////////////////////////////////////////////////////////////

#endregion

namespace Dexter.Shared.Exceptions
{
	public class DexterSecurityException : DexterException
	{
		#region Constructors and Destructors

		public DexterSecurityException(string message)
			: base(message)
		{
		}

		protected DexterSecurityException()
		{
		}

		#endregion
	}
}