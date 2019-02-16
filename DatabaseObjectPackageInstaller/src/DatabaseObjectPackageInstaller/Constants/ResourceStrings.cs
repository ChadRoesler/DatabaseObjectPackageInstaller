namespace DatabaseObjectPackageInstaller.Constants
{
    internal sealed class ResourceStrings
    {
        internal readonly static string StagingWorkingDirectory = @"{0}\DOPI\Installer\DatabaseObjects";
        internal readonly static string TemporaryWorkingDirectory = @"{0}\DOPI\Installer\DatabaseObjects\staging";
        internal readonly static string SequenceManifestName = @"sequence.txt";
        internal readonly static string SqlDirectory = @"Sql";
        internal readonly static string SequenceManifestPathCheck = @"{0}\sequence.txt";
        internal readonly static string DatabaseObjectFolderAndName = @"{0}\{1}";
        internal readonly static string SqlFileTypeSearchPattern = "*.sql";
        internal readonly static string ProcedureStubQueryFormat = "CREATE PROCEDURE [dbo].[{0}] AS BEGIN SELECT 1 END";
        internal readonly static string FunctionStubQueryFormat = "CREATE FUNCTION [dbo].[{0}] (@a int) RETURNS int AS BEGIN /* Stub */ RETURN @a END";
        internal readonly static string ViewStubQueryFormat = "CREATE VIEW [dbo].[{0}] AS SELECT '''' as [stub]";
        internal readonly static string DefaultStubQuery = "SELECT 1";
        internal readonly static string ExistenceCheckFormat =  @"IF OBJECT_ID('dbo.{0}') IS NULL
    BEGIN
        exec('{1}')
    END";
        internal readonly static string ApplicationName = "DatabaseObjectPackageInstaller";
        internal readonly static string NewLineHandler = $"{System.Environment.NewLine}";
        internal readonly static string ErrorAppender = $"{{0}}{NewLineHandler}{{1}}";
        internal const string LeftOfBatchGroupMarker = "LEFT";
        internal const string RightOfBatchGroupMarker = "RIGHT";
        internal const string BatchGroupMarker = "BATCHGROUP";
        internal const string RemovalMarker = "_REMOVE_";
        internal const string BatchTerminator = "GO";



        internal readonly static string FormattedBatchTerminator = $@"{System.Environment.NewLine}{BatchTerminator}{System.Environment.NewLine}";
        internal readonly static string SqlStringPattern = $@"(?<{LeftOfBatchGroupMarker}>'[^']*')";
        internal readonly static string SingleLineCommentsPattern = $@"(?<{LeftOfBatchGroupMarker}>--.*$)";
        internal readonly static string BlockCommentPattern = $@"(?<{LeftOfBatchGroupMarker}>/\*[\S\s]*?\*/)";
        internal readonly static string BatchPattern = $@"(?<{LeftOfBatchGroupMarker}>^|\s)(?<{BatchGroupMarker}>{BatchTerminator})(?<{RightOfBatchGroupMarker}>\s|$)";
        internal readonly static string SplitPattern = $@"\|\{{\[{RemovalMarker}\]\}}\|";
        internal readonly static string RemovalPattern = $@" |{{[{RemovalMarker}]}}| ";
        internal readonly static string MarkerPattern = $@"{SqlStringPattern}|{SingleLineCommentsPattern}|{BlockCommentPattern }|{BatchPattern}";
    }
}
