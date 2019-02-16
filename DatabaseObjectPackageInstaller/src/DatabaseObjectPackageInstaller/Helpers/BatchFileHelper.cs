using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DatabaseObjectPackageInstaller.Constants;

namespace DatabaseObjectPackageInstaller.Helpers
{
	/// <summary>
	/// Refactored from the following sources:
	///		- https://github.com/chucknorris/roundhouse/blob/e9d71a38e6bd4fa3edcf5b260a7c2e7e874eaeac/product/roundhouse.databases.sqlserver/SqlServerDatabase.cs
	///		- https://github.com/chucknorris/roundhouse/blob/971d047908c93ec2c8134074277cfb3929f57979/product/roundhouse/sqlsplitters/StatementSplitter.cs
	/// </summary>
	internal static class BatchFileHelper
	{
		internal static bool HasTextToRun(string sqlStatement)
		{
			sqlStatement = Regex.Replace(sqlStatement, ResourceStrings.SplitPattern, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Multiline).Replace(Environment.NewLine, string.Empty);

			if (string.IsNullOrWhiteSpace(sqlStatement))
			{
				return false;
			}

			return true;
		}

		/// <summary>
		///	Replaces items marked with the batch marker for delineating relevant GO statements with the removal pattern for further processing.
		/// </summary>
		/// <param name="matchedItem">A match as returned from the Regex.Replace() method</param>
		/// <returns></returns>
		internal static string ReplaceBatchSplitItems(Match matchedItem)
		{
			if (matchedItem.Groups[ResourceStrings.BatchGroupMarker].Success)
			{
				return $@"{matchedItem.Groups[ResourceStrings.LeftOfBatchGroupMarker].Value}{ResourceStrings.RemovalPattern}{matchedItem.Groups[ResourceStrings.RightOfBatchGroupMarker].Value}";
			}
			else
			{
				return $@"{matchedItem.Groups[ResourceStrings.LeftOfBatchGroupMarker].Value}{matchedItem.Groups[ResourceStrings.RightOfBatchGroupMarker].Value}";
			}
		}
		/// <summary>
		/// Builds a
		/// </summary>
		/// <param name="sqlToRun"></param>
		/// <returns></returns>
		public static IEnumerable<string> GetBatches(string sqlToRun)
		{
			IList<string> batches = new List<string>();

			var markerRegex = new Regex(ResourceStrings.MarkerPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

			/* Recursively mark the SQL with Regex Groups.
			 *
			 * These groups mark:
			 * - Relevant batch terminators within context (outside of comment blocks, outside of value statements, etc) and mark them for deletion
			 * - Batches left and right of the batch terminator
			 *
			 * These markers can then be processed by further processors
			 */
			var markedSql = markerRegex.Replace(sqlToRun, match => ReplaceBatchSplitItems(match));

			/* Recursively split the SQL statement into batches using the Removal group */
			var parsedBatches = Regex.Split(markedSql, ResourceStrings.SplitPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

			foreach (string batch in parsedBatches)
			{
				if (HasTextToRun(batch))
				{
					batches.Add(batch);
				}
			}

			return batches;
		}
	}
}
