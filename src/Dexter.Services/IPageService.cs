﻿#region Disclaimer/Info

// ////////////////////////////////////////////////////////////////////////////////////////////////
// File:			IPageService.cs
// Website:		http://dexterblogengine.com/
// Authors:		http://dexterblogengine.com/aboutus
// Created:		2012/11/01
// Last edit:	2013/03/23
// License:		New BSD License (BSD)
// For updated news and information please visit http://dexterblogengine.com/
// Dexter is hosted to Github at https://github.com/imperugo/Dexter-Blog-Engine
// For any question contact info@dexterblogengine.com
// ////////////////////////////////////////////////////////////////////////////////////////////////

#endregion

namespace Dexter.Services
{
	using System;
	using System.Security.Permissions;

	using Dexter.Entities;
	using Dexter.Entities.Filters;
	using Dexter.Entities.Result;
	using Dexter.Services.Events;
	using Dexter.Shared;

	public interface IPageService
	{
		#region Public Events

		/// <summary>
		/// This event will raise after the <see cref="PageDto"/> is delete. The event is raised by by the implementation of <see cref="Delete"/> or the async version.
		/// </summary>
		event EventHandler<EventArgs> PageDeleted;

		/// <summary>
		/// This event will raise before to delete <see cref="PageDto"/>. The event is raised by by the implementation of <see cref="Delete"/> or the async version.
		/// </summary>
		event EventHandler<CancelEventArgsWithOneParameterWithoutResult<int>> PageDeleting;

		/// <summary>
		/// This event will raise after to retrieve <see cref="PageDto"/> by specific key. The event is raised by by the implementation of <see cref="GetPageByKey"/> or the async version.
		/// </summary>
		event EventHandler<GenericEventArgs<PageDto>> PageRetrievedById;

		/// <summary>
		/// This event will raise after to retrieve <see cref="PageDto"/> by specific slug. The event is raised by by the implementation of <see cref="GetPageBySlug"/> or the async version.
		/// </summary>
		event EventHandler<GenericEventArgs<PageDto>> PageRetrievedBySlug;

		/// <summary>
		/// This event will raise before to retrieve <see cref="PageDto"/> by specific key. The event is raised by by the implementation of <see cref="GetPageByKey"/> or the async version.
		/// </summary>
		event EventHandler<CancelEventArgsWithOneParameter<int, PageDto>> PageRetrievingById;

		/// <summary>
		/// This event will raise before to retrieve <see cref="PageDto"/> by specific slug. The event is raised by by the implementation of <see cref="GetPageBySlug"/> or the async version.
		/// </summary>
		event EventHandler<CancelEventArgsWithOneParameter<string, PageDto>> PageRetrievingBySlug;

		/// <summary>
		/// This event will raise after the <see cref="PageDto"/> is saved. The event is raised by by the implementation of <see cref="SaveOrUpdate"/> or the async version.
		/// </summary>
		event EventHandler<CancelEventArgsWithoutParameterWithResult<PageDto>> PageSaved;

		/// <summary>
		/// This event will raise before to save <see cref="PageDto"/>. The event is raised by by the implementation of <see cref="SaveOrUpdate"/> or the async version.
		/// </summary>
		event EventHandler<CancelEventArgsWithOneParameterWithoutResult<PageDto>> PageSaving;

		/// <summary>
		/// This event will raise after to retrieve <see cref="IPagedResult"/> of <see cref="PageDto"/> with specific filters. The event is raised by by the implementation of <see cref="GetPages"/> or the async version.
		/// </summary>
		event EventHandler<GenericEventArgs<IPagedResult<PageDto>>> PagesRetrievedWithFilters;

		/// <summary>
		/// This event will raise before to retrieve <see cref="IPagedResult"/> of <see cref="PageDto"/> with specific filters. The event is raised by by the implementation of <see cref="GetPages"/> or the async version.
		/// </summary>
		event EventHandler<CancelEventArgsWithOneParameter<Tuple<int, int, ItemQueryFilter>, IPagedResult<PageDto>>> PagesRetrievingWithFilters;

		#endregion

		#region Public Methods and Operators

		[PrincipalPermission(SecurityAction.PermitOnly, Authenticated = true, Role = Constants.Editor)]
		[PrincipalPermission(SecurityAction.PermitOnly, Authenticated = true, Role = Constants.AdministratorRole)]
		void Delete(int key);

		string[] GetAllSlugs();

		PageDto GetPageByKey(int key);

		PageDto GetPageBySlug(string slug);

		IPagedResult<PageDto> GetPages(int pageIndex, int pageSize, ItemQueryFilter filters);

		[PrincipalPermission(SecurityAction.PermitOnly, Authenticated = true, Role = Constants.Editor)]
		[PrincipalPermission(SecurityAction.PermitOnly, Authenticated = true, Role = Constants.AdministratorRole)]
		void SaveOrUpdate(PageDto item);

		#endregion
	}
}