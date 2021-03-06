﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DatabaseObjectPackageInstaller.Constants;
using DatabaseObjectPackageInstaller.Enums;
using DatabaseObjectPackageInstaller.Helpers;
using DatabaseObjectPackageInstaller.Models.Interfaces;

namespace DatabaseObjectPackageInstaller.Workers
{
    internal class PackageExecutor
    {

        private static readonly string stagingPath = string.Format(ResourceStrings.StagingWorkingDirectory, Path.GetTempPath());
        private readonly IPackageSettings sessionPackageSettings;
        private readonly IDatabaseSettings sessionDatabaseSettings;
        private readonly ICommonSettings sessionCommonSettings;

        internal PackageExecutor(IPackageSettings packageSettings, IDatabaseSettings databaseSettings, ICommonSettings commonSettings)
        {
            sessionPackageSettings = packageSettings;
            sessionDatabaseSettings = databaseSettings;
            sessionCommonSettings = commonSettings;
        }

        internal Task Install(IProgress<Dictionary<ProgressType, string>> progress, CancellationToken cancelToken)
        {
            int errorCount = 0;
            List<string> errorList = new List<string>();
            return Task.Run(() =>
            {
                try
                {
                    var progressStartDictionary = new Dictionary<ProgressType, string>
                    {
                        [ProgressType.Output] = MessageStrings.GatheringDatabaseObjects,
                        [ProgressType.Name] = MessageStrings.GatheringDatabaseObjects
                    };

                    progress.Report(progressStartDictionary);

                    var packagePath = sessionPackageSettings.PackagePath;

                    if (CompressedFileHelper.IsFileCompressed(sessionPackageSettings.PackagePath))
                    {
                        packagePath = CompressedFileHelper.ExtractFiles(sessionPackageSettings.PackagePath, stagingPath);
                    }
                    var sqlConn = new SqlServerConnection().DatabaseConnection(sessionDatabaseSettings);
                    var databaseObjectList = PackageHelper.GetDatabaseObjectsFromPackage(packagePath);

                    var progressSizeDictionary = new Dictionary<ProgressType, string>
                    {
                        [ProgressType.Size] = (databaseObjectList.Count + 1).ToString()
                    };
                    var count = 1;
                    progressSizeDictionary[ProgressType.StepCount] = count.ToString();
                    progress.Report(progressSizeDictionary);

                    if (!cancelToken.IsCancellationRequested)
                    {
                        foreach (var databaseObject in databaseObjectList)
                        {
                            count++;
                            var progressDatabaseObjectDictionary = new Dictionary<ProgressType, string>
                            {
                                [ProgressType.Output] = databaseObject.DatabaseObjectFolderAndName,
                                [ProgressType.Name] = string.Format(MessageStrings.Executing, databaseObject.DatabaseObjectName),
                                [ProgressType.StepCount] = count.ToString()
                            };
                            if (sessionCommonSettings.Verbose)
                            {
                                progress.Report(progressDatabaseObjectDictionary);
                            }
                            try
                            {
                                var fileText = File.ReadAllText(databaseObject.DatabaseObjectPath, Encoding.UTF8);
                                SqlHelper.ExecSQLReturn(sqlConn, databaseObject.CreateStatement);
                                var sqlBatches = BatchFileHelper.GetBatches(fileText);
                                foreach (var batch in sqlBatches)
                                {
                                    SqlHelper.ExecSQLReturn(sqlConn, batch);
                                }
                            }
                            catch (Exception ex)
                            {
                                var progressDatabaseObjectErrorDictionary = new Dictionary<ProgressType, string>();
                                if (sessionPackageSettings.Custom)
                                {
                                    errorCount++;
                                    errorList.Add(ex.Message);
                                    progressDatabaseObjectErrorDictionary[ProgressType.Warning] = ex.Message;
                                    progressDatabaseObjectErrorDictionary[ProgressType.BarStatus] = ProgressBarStatusType.Warning.ToString();
                                    progress.Report(progressDatabaseObjectErrorDictionary);
                                }
                                else
                                {
                                    throw new Exception(ex.Message);
                                }
                            }
                            if (cancelToken.IsCancellationRequested)
                            {
                                break;
                            }
                        }
                    }
                    var progressCompleteDictionary = new Dictionary<ProgressType, string>();
                    if (cancelToken.IsCancellationRequested)
                    {
                        progressCompleteDictionary[ProgressType.Name] = MessageStrings.ProgressCancelled;
                        progressCompleteDictionary[ProgressType.Output] = MessageStrings.ProgressCancelled;
                        progressCompleteDictionary[ProgressType.BarStatus] = ProgressType.Warning.ToString();
                        if (errorCount > 0)
                        {
                            progressCompleteDictionary[ProgressType.Error] = string.Join(Environment.NewLine, errorList);
                        }
                    }
                    else
                    {
                        if (errorCount > 0)
                        {
                            progressCompleteDictionary[ProgressType.Name] = MessageStrings.ProgressFailed;
                            progressCompleteDictionary[ProgressType.Output] = MessageStrings.ProgressFailed;
                            progressCompleteDictionary[ProgressType.Error] = string.Join(Environment.NewLine, errorList);
                        }
                        else
                        {
                            progressCompleteDictionary[ProgressType.Name] = MessageStrings.ProgressComplete;
                            progressCompleteDictionary[ProgressType.Output] = MessageStrings.ProgressComplete;
                        }
                    }
                    progress.Report(progressCompleteDictionary);
                }
                catch(Exception ex)
                {
                    var progressCriticalErrorDictionary = new Dictionary<ProgressType, string>
                    {
                        [ProgressType.Error] = ex.Message,
                        [ProgressType.Name] = MessageStrings.ProgressFailed,
                        [ProgressType.BarStatus] = ProgressBarStatusType.Error.ToString()
                    };
                    progress.Report(progressCriticalErrorDictionary);
                }
            }, cancelToken);
        }
    }
}
