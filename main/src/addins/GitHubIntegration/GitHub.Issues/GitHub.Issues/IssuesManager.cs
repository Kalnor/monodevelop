﻿using System;
using GitHub.Auth;
using Octokit;
using System.Collections.Generic;
using Gtk;

namespace GitHub.Issues
{
	public class IssuesManager
	{
		private GitHubClient gitHubClient = null;

		public IssuesManager ()
		{
			this.gitHubClient = GitHubService.Client;
		}

		public async void GetAllIssues()
		{
			IReadOnlyList<Octokit.Issue> allIssues = await gitHubClient.Issue.GetForRepository ("Kalnor", "testRepo");

			String issueListString = "";

			foreach (Octokit.Issue issue in allIssues) {
				String assigned = "Not Assigned";

				if (issue.Assignee != null) {
					assigned = issue.Assignee.Login;
				}

				issueListString += String.Format ("    {0} - {1} - {2}    \n", issue.Title, issue.Body, assigned);
			}
		}
	}
}