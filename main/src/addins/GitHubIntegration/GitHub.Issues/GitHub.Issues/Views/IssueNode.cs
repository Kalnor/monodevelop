﻿using System;
using Octokit;
using Gtk;
using System.ComponentModel;

namespace GitHub.Issues
{
	public class IssueNode
	{
		private Octokit.Issue issue;

		[Description("Title")]
		public String Title { get { return this.issue.Title; } }
		[Description("Description")]
		public String Body { get { return this.issue.Body; } }
		[Description("Assigned To")]
		public String Assigee { get { return this.issue.Assignee != null ? this.issue.Assignee.Login : "Unassigned"; } }
		[Description("Last Updated At")]
		public String UpdatedAt { get { return this.issue.UpdatedAt.ToString (); } }
		[Description("State")]
		public String State { get { return this.issue.State.ToString (); } }
		[Description("Labels")]
		public String Labels
		{
			get {
				String labels = "";

				foreach (Octokit.Label label in this.issue.Labels) {
					labels += label.Name + ", ";
				}

				labels = labels.Trim ();

				if (labels.Length > 0) {
					labels = labels.Remove (labels.Length - 1);
				}

				return labels;
			}
		}

		public IssueNode (Octokit.Issue issue)
		{
			this.issue = issue;
		}
	}
}

