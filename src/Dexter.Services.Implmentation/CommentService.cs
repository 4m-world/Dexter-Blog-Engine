﻿#region Disclaimer/Info

// ////////////////////////////////////////////////////////////////////////////////////////////////
// File:			CommentService.cs
// Website:		http://dexterblogengine.com/
// Authors:		http://dexterblogengine.com/aboutus
// Created:		2012/11/01
// Last edit:	2013/01/20
// License:		New BSD License (BSD)
// For updated news and information please visit http://dexterblogengine.com/
// Dexter is hosted to Github at https://github.com/imperugo/Dexter-Blog-Engine
// For any question contact info@dexterblogengine.com
// ////////////////////////////////////////////////////////////////////////////////////////////////
#endregion

namespace Dexter.Services.Implmentation
{
	using System;
	using System.Collections.Generic;

	using Dexter.Data;
	using Dexter.Entities;
	using Dexter.Entities.Filters;
	using Dexter.Services.Events;

	public class CommentService : ICommentService
	{
		#region Fields

		private readonly ICommentDataService commentDataService;

		private readonly IConfigurationService configurationService;

		#endregion

		#region Constructors and Destructors

		public CommentService(ICommentDataService commentDataService, IConfigurationService configurationService)
		{
			this.commentDataService = commentDataService;
			this.configurationService = configurationService;
		}

		#endregion

		#region Public Events

		public event EventHandler<GenericEventArgs<IList<CommentDto>>> CommentsRetrievedByItemId;

		public event EventHandler<CancelEventArgsWithOneParameter<int, IList<CommentDto>>> CommentsRetrievingByItemId;

		public event EventHandler<GenericEventArgs<IList<CommentDto>>> RecentCommentsRetrieved;

		public event EventHandler<CancelEventArgsWithOneParameter<int, IList<CommentDto>>> RecentRetrieving;

		#endregion

		#region Public Methods and Operators

		public void AddComment(CommentDto item, int itemId)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item", "The comment item must contain a valid instance.");
			}

			if (itemId < 1)
			{
				throw new ArgumentException("The item id must be greater than 0", "itemId");
			}

			BlogConfigurationDto configuration = this.configurationService.GetConfiguration();

			CommentStatus status = configuration.CommentSettings.EnablePremoderation ? CommentStatus.Pending : CommentStatus.IsApproved;

			this.commentDataService.AddComment(item, itemId, status);
		}

		public IList<CommentDto> GetCommentForSpecificItem(int itemId, CommentQueryFilter queryFilter)
		{
			if (itemId < 1)
			{
				throw new ArgumentException("The item id must be greater than 0", "itemId");
			}

			if (queryFilter == null)
			{
				queryFilter = new CommentQueryFilter();
				queryFilter.CommentStatus = CommentStatus.IsApproved;
			}

			CancelEventArgsWithOneParameter<int, IList<CommentDto>> e = new CancelEventArgsWithOneParameter<int, IList<CommentDto>>(itemId, null);

			this.CommentsRetrievingByItemId.Raise(this, e);

			if (e.Cancel)
			{
				return e.Result;
			}

			IList<CommentDto> result = this.commentDataService.GetCommentForSpecificItem(itemId, queryFilter);

			this.CommentsRetrievedByItemId(this, new GenericEventArgs<IList<CommentDto>>(result));

			return result;
		}

		public IList<CommentDto> GetRecentComments(int maxNumber, CommentQueryFilter queryFilter = null)
		{
			if (maxNumber < 1)
			{
				throw new ArgumentException("The number of item to rtrieve must be greater than 0.", "maxNumber");
			}

			if (queryFilter == null)
			{
				queryFilter = new CommentQueryFilter();
				queryFilter.CommentStatus = CommentStatus.IsApproved;
			}

			return null;
		}

		#endregion
	}
}