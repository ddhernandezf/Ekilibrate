﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl`1[[MvcSiteMapProvider.Web.Html.Models.SiteMapDescriptionHelperModel,MvcSiteMapProvider]]" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>
<%@ Import Namespace="MvcSiteMapProvider.Web.Html.Models" %>

<% if (Model.CurrentNode != null && !string.IsNullOrEmpty(Model.CurrentNode.Description)) { %>
<%= Model.CurrentNode.Description %>"
<% } %>