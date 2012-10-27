﻿namespace Dexter.Dependency.Castle.Test
{
	using System;

	using Dexter.Dependency.Castle.Container;
	using Dexter.Dependency.Castle.Test.Helpers;

	using SharpTestsEx;

	using Xunit;

	public class CastleContainerTest : IDisposable
	{
		#region Fields

		private CastleContainer sut;

		#endregion

		#region Constructors and Destructors

		public CastleContainerTest()
		{
			this.sut = new CastleContainer();

			this.sut.Configure(null);
		}

		#endregion

		#region Public Methods and Operators

		public void Dispose()
		{
			this.sut.Shutdown();
			this.sut = null;
		}

		[Fact]
		public void RegisterOfT_ForTheCurrentAssembly_ShouldRegisterTheBaseTypeAndNotTheImplemented()
		{
			this.sut.Register<ITestInterface>(this.GetType().Assembly, LifeCycle.Singleton);

			ITestInterface[] result = this.sut.ResolveAll<ITestInterface>();

			result.Length.Should().Be.EqualTo(3);
		}

		[Fact]
		public void ResolveAll_WithValidComponents_ShouldReturnValidData()
		{
			this.sut.Register<ITestInterface, TestClass1>(LifeCycle.Transient);
			this.sut.Register<ITestInterface, TestClass2>(LifeCycle.Transient);
			this.sut.Register<ITestInterface, TestClass3>(LifeCycle.Transient);

			ITestInterface[] result = this.sut.ResolveAll<ITestInterface>();

			result.Length.Should().Be.EqualTo(3);
		}

		#endregion
	}
}